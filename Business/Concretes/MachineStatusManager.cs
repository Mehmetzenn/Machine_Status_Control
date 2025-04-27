using Business.Abstract;
using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class MachineStatusManager : IMachineStatusService
    {
        private readonly IMachineStatusDal _machineStatusDal;
        private readonly IShiftService _shiftService;

        public MachineStatusManager(IMachineStatusDal machineStatusDal, IShiftService shiftService)
        {
            _machineStatusDal = machineStatusDal;
            _shiftService = shiftService;
        }

        public IResult Add(MachineStatus machineStatus)
        {
            _machineStatusDal.Add(machineStatus);
            return new SuccessResult("Makine durumu başarıyla eklendi.");
        }

        public IDataResult<TimeSpan> CalculateWorkingTime(List<MachineStatus> statuses)
        {
            if (statuses == null || statuses.Count == 0)
            {
                return new ErrorDataResult<TimeSpan>(TimeSpan.Zero, "Makine durumu verisi bulunamadı.");
            }

            // Tarih ve saat'e göre sırala
            var sortedStatuses = statuses.OrderBy(s => s.Date).ThenBy(s => s.Time).ToList();

            TimeSpan totalWorkingTime = TimeSpan.Zero;
            DateTime? workingStart = null;

            foreach (var status in sortedStatuses)
            {
                var currentDateTime = status.Date + status.Time;

                if (status.StatusId == 1) // ÇALIŞIYOR
                {
                    if (workingStart == null)
                    {
                        workingStart = currentDateTime; // Başlat
                    }
                }
                else
                {
                    if (workingStart != null)
                    {
                        // Çalışıyordu, şimdi durduysa süreyi ekle
                        totalWorkingTime += currentDateTime - workingStart.Value;
                        workingStart = null;
                    }
                }
            }

            // Listenin sonunda hala çalışıyorsa, şu ana kadar ekle
            if (workingStart != null)
            {
                var lastDateTime = sortedStatuses.Last().Date + sortedStatuses.Last().Time;
                totalWorkingTime += lastDateTime - workingStart.Value;
            }

            return new SuccessDataResult<TimeSpan>(totalWorkingTime, "Toplam çalışma süresi hesaplandı.");
        }


        public IResult Delete(MachineStatus machineStatus)
        {
            _machineStatusDal.Delete(machineStatus);
            return new SuccessResult("Makine durumu başarıyla silindi.");
        }

        public IDataResult<List<MachineStatus>> GetAll()
        {
            var machineStatuses = _machineStatusDal.GetAll();
            return new SuccessDataResult<List<MachineStatus>>(machineStatuses);
        }

        public IDataResult<MachineStatus> GetById(int id)
        {
            var machineStatus = _machineStatusDal.Get(m => m.Id == id);
            return new SuccessDataResult<MachineStatus>(machineStatus);
        }

        public IDataResult<List<MachineStatus>> GetByMachineIdAndShift(int machineId, TimeSpan time, DateTime date)
        {
            var shifts = _shiftService.GetAll().Data;

            // Time'a göre uygun vardiyayı bul
            var matchedShift = shifts.FirstOrDefault(shift =>
                shift.StartTime < shift.EndTime
                    ? time >= shift.StartTime && time < shift.EndTime
                    : time >= shift.StartTime || time < shift.EndTime);

            if (matchedShift == null)
            {
                return new ErrorDataResult<List<MachineStatus>>("Uygun vardiya bulunamadı.");
            }

            // Bu vardiyanın zaman aralığını al
            var shiftStart = matchedShift.StartTime;
            var shiftEnd = matchedShift.EndTime;

            // Vardiya 00:00 geçişi yapıyorsa (örneğin 24-08 vardiyası)
            List<MachineStatus> result;

            if (shiftStart < shiftEnd)
            {
                result = _machineStatusDal.GetAll(ms =>
                    ms.MachineId == machineId &&
                    ms.Date == date &&
                    ms.Time >= shiftStart && ms.Time < shiftEnd);
            }
            else
            {
                // Gece vardiyası durumu: 23:00 – 07:00 gibi
                result = _machineStatusDal.GetAll(ms =>
                    ms.MachineId == machineId &&
                    (
                        (ms.Date == date && ms.Time >= shiftStart) ||
                        (ms.Date == date.AddDays(1) && ms.Time < shiftEnd)
                    )
                );
            }

            return new SuccessDataResult<List<MachineStatus>>(result);
        }


        public IDataResult<List<MachineStatus>> GetLastStatusByMachineId(int machineId)
        {
            return new SuccessDataResult<List<MachineStatus>>(_machineStatusDal.GetAll(m => m.MachineId == machineId));
        }

        public IResult Update(MachineStatus machineStatus)
        {
            _machineStatusDal.Update(machineStatus);
            return new SuccessResult("Makine durumu başarıyla güncellendi.");
        }
    }
}

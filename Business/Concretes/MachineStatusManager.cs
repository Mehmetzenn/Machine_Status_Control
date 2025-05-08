using Business.Abstract;
using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Abstracts;
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

        public IDataResult<List<MachineStatus>> GetByMachineIdAndDate(int machineId, DateTime date)
        {
            var result = _machineStatusDal.GetAll(ms => ms.MachineId == machineId && ms.Date.Date == date.Date);

            if (result == null || result.Count == 0)
            {
                return new ErrorDataResult<List<MachineStatus>>("Veri bulunamadı fbvbf.");
            }

            return new SuccessDataResult<List<MachineStatus>>(result, "Veriler başarıyla getirildi.");
        }

        public IResult Update(MachineStatus machineStatus)
        {
            _machineStatusDal.Update(machineStatus);
            return new SuccessResult("Makine durumu başarıyla güncellendi.");
        }

        public IDataResult<List<MachineStatus>> GetByCurrentShift()
        {
            var now = DateTime.Now;
            int currentShiftId;

            if (now.TimeOfDay >= TimeSpan.FromHours(8) && now.TimeOfDay < TimeSpan.FromHours(16))
            {
                currentShiftId = 1;
            }
            else if (now.TimeOfDay >= TimeSpan.FromHours(16) && now.TimeOfDay < TimeSpan.FromHours(24))
            {
                currentShiftId = 2;
            }
            else
            {
                currentShiftId = 3;
            }

            var result = _machineStatusDal.GetAll(m =>
                m.Date == now.Date && m.ShiftId == currentShiftId
            );

            return new SuccessDataResult<List<MachineStatus>>(result);
        }

        public IDataResult<List<MachineStatusDto>> GetStatusDetail()
        {
            return new SuccessDataResult<List<MachineStatusDto>>(_machineStatusDal.GetStatusDetail(), "Makine durumu detayları başarıyla getirildi.");
        }
    }
}

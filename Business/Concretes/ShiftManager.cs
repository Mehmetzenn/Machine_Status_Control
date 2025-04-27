using Business.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concretes
{
    public class ShiftManager : IShiftService
    {
        private readonly IShiftDal _shiftDal;

        public ShiftManager(IShiftDal shiftDal)
        {
            _shiftDal = shiftDal;
        }

        public IResult Add(Shift shift)
        {
            try
            {
                _shiftDal.Add(shift);
                return new SuccessResult("Vardiya başarıyla eklendi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Vardiya eklenirken bir hata oluştu: " + ex.Message);
            }
        }

        public IResult Delete(Shift shift)
        {
            try
            {
                _shiftDal.Delete(shift);
                return new SuccessResult("Vardiya başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Vardiya silinirken bir hata oluştu: " + ex.Message);
            }
        }

        public IDataResult<List<Shift>> GetAll()
        {
            try
            {
                var shifts = _shiftDal.GetAll().ToList();
                return new SuccessDataResult<List<Shift>>(shifts, "Vardiyalar başarıyla getirildi.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Shift>>(null, "Vardiyalar getirilirken bir hata oluştu: " + ex.Message);
            }
        }

        public IDataResult<Shift> GetById(int id)
        {
            try
            {
                var shift = _shiftDal.Get(s => s.Id == id);
                if (shift != null)
                {
                    return new SuccessDataResult<Shift>(shift, "Vardiya başarıyla getirildi.");
                }
                return new ErrorDataResult<Shift>(null, "Vardiya bulunamadı.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Shift>(null, "Vardiya getirilirken bir hata oluştu: " + ex.Message);
            }
        }

        public IDataResult<List<Shift>> GetLastStatusByMachineId(int shiftId)
        {
            try
            {
                var shifts = _shiftDal.GetAll().Where(s => s.Id == shiftId).ToList();
                if (shifts.Any())
                {
                    return new SuccessDataResult<List<Shift>>(shifts, "Vardiya durumu başarıyla getirildi.");
                }
                return new ErrorDataResult<List<Shift>>(null, "Vardiya durumu bulunamadı.");
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<Shift>>(null, "Vardiya durumu getirilirken bir hata oluştu: " + ex.Message);
            }
        }

        public IResult Update(Shift shift)
        {
            try
            {
                _shiftDal.Update(shift);
                return new SuccessResult("Vardiya başarıyla güncellendi.");
            }
            catch (Exception ex)
            {
                return new ErrorResult("Vardiya güncellenirken bir hata oluştu: " + ex.Message);
            }
        }
    }
}

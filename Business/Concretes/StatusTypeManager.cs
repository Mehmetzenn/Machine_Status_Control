using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System.Collections.Generic;

namespace Business.Concretes
{
    public class StatusTypeManager : IStatusTypeService
    {
        private readonly IStatusTypeDal _statusTypeDal;

        public StatusTypeManager(IStatusTypeDal statusTypeDal)
        {
            _statusTypeDal = statusTypeDal;
        }

        public IResult Add(StatusType statusType)
        {
            _statusTypeDal.Add(statusType);
            return new SuccessResult("Durum türü eklendi.");
        }

        public IResult Delete(StatusType statusType)
        {
            _statusTypeDal.Delete(statusType);
            return new SuccessResult("Durum türü silindi.");
        }

        public IDataResult<List<StatusType>> GetAll()
        {
            var data = _statusTypeDal.GetAll();
            return new SuccessDataResult<List<StatusType>>(data);
        }

        public IDataResult<StatusType> GetById(int id)
        {
            var data = _statusTypeDal.Get(s => s.Id == id);
            return new SuccessDataResult<StatusType>(data);
        }

        public IResult Update(StatusType statusType)
        {
            _statusTypeDal.Update(statusType);
            return new SuccessResult("Durum türü güncellendi.");
        }
    }
}

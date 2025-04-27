using Core.Utilities.Results;
using Entities.Concretes;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IStatusTypeService
    {
        IDataResult<List<StatusType>> GetAll();
        IDataResult<StatusType> GetById(int id);
        IResult Add(StatusType statusType);
        IResult Update(StatusType statusType);
        IResult Delete(StatusType statusType);
    }
}

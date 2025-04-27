using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IShiftService
    {
        IDataResult<List<Shift>> GetAll();
        IDataResult<Shift> GetById(int id);
        IDataResult<List<Shift>> GetLastStatusByMachineId(int shiftId);
        IResult Add(Shift shift);
        IResult Update(Shift shift);
        IResult Delete(Shift shift);
    }
}

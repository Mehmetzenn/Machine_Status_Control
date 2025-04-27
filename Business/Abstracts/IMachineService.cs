using Core.Utilities.Results;
using Entities.Concretes;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using Machine = Entities.Concretes.Machine;

namespace Business.Abstract
{
    public interface IMachineService
    {
        IDataResult<List<Machine>> GetAll();
        IDataResult<Machine> GetById(int id);
        IResult Add(Machine machine);
        IResult Update(Machine machine);
        IResult Delete(Machine machine);
    }
}

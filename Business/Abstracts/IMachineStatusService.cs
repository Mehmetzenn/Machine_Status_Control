using Core.Utilities.Results;
using Entities.Abstracts;
using Entities.Concretes;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMachineStatusService
    {
        IDataResult<List<MachineStatus>> GetAll();
        IDataResult<MachineStatus> GetById(int id);
        IResult Add(MachineStatus machineStatus);
        IDataResult<List<MachineStatus>> GetByMachineIdAndDate(int machineId, DateTime date);
        IResult Update(MachineStatus machineStatus);
        IResult Delete(MachineStatus machineStatus);
        IDataResult<List<MachineStatusDto>> GetStatusDetail();
        IDataResult<List<MachineStatus>> GetByCurrentShift();


    }
}

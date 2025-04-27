using Core.Utilities.Results;
using Entities.Concretes;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMachineStatusService
    {
        IDataResult<List<MachineStatus>> GetAll();
        IDataResult<MachineStatus> GetById(int id);
        IDataResult<List<MachineStatus>> GetLastStatusByMachineId(int machineId);
        IResult Add(MachineStatus machineStatus);
        IResult Update(MachineStatus machineStatus);
        IResult Delete(MachineStatus machineStatus);
        IDataResult<List<MachineStatus>> GetByMachineIdAndShift(int machineId, TimeSpan time, DateTime date);
        IDataResult<TimeSpan> CalculateWorkingTime(List<MachineStatus> statuses);

    }
}

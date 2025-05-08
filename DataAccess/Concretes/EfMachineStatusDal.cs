using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class EfMachineStatusDal : EfEntityRepositoryBase<MachineStatus, MachineStatusControlContext>, IMachineStatusDal
    {
        public List<MachineStatusDto> GetStatusDetail()
        {
            using (MachineStatusControlContext context = new MachineStatusControlContext())
            {
                var result = from ms in context.machineStatus
                             join m in context.machines
                             on ms.MachineId equals m.Id
                             join s in context.statusTypes
                             on ms.StatusId equals s.Id
                             join sh in context.shift
                             on ms.ShiftId equals sh.Id
                             select new MachineStatusDto
                             {
                                 Id = ms.Id,
                                 MachineName = m.Name,
                                 Status = s.Name,
                                 Date = ms.Date,
                                 Shift = sh.Name
                             };
                return result.ToList();
            }
        }
    }
}

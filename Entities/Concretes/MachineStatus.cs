using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class MachineStatus : IEntity
    {
        public int Id { get; set; }

        public int MachineId { get; set; }
        public int StatusId { get; set; }
        
        public int ShiftId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }

    }
}

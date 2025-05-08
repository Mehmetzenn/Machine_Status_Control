using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstracts
{
    public class MachineStatusDto
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public string Shift { get; set; }  

    }
}

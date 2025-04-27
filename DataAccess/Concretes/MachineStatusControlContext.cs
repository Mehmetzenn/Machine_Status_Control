using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes
{
    public class MachineStatusControlContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=Machine_Status_Control;Trusted_Connection=True;");
        }
        public DbSet<StatusType> statusTypes { get; set; }
        public DbSet<Machine> machines { get; set; }
        public DbSet<MachineStatus> machineStatus { get; set; }
        public DbSet<Shift> shift { get; set; }

    }
}

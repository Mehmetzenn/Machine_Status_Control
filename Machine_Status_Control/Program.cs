using Business.Abstract;
using Business.Abstracts;
using Business.Concrete;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Machine_Status_Control
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            // StatusType
            services.AddScoped<IStatusTypeService, StatusTypeManager>();
            services.AddScoped<IStatusTypeDal, EfStatusTypeDal>();

            // Machine
            services.AddScoped<IMachineService, MachineManager>();
            services.AddScoped<IMachineDal, EfMachineDal>();
            
            // MachineStatus
            services.AddScoped<IMachineStatusService, MachineStatusManager>();
            services.AddScoped<IMachineStatusDal, EfMachineStatusDal>();

            // Shift
            services.AddScoped<IShiftService, ShiftManager>();
            services.AddScoped<IShiftDal, EfShiftDal>();

            // Form
            services.AddScoped<Form1>();
            var serviceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(serviceProvider.GetRequiredService<Form1>());
        }
    }
}

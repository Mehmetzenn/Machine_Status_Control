using Business.Abstract;
using Business.Abstracts;
using Business.Concrete;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Uygulamanýn belirtilen IP ve port üzerinden yayýn yapmasý
//builder.WebHost.UseUrls("http://192.168.1.7:5000");

// Dependency Injection
builder.Services.AddScoped<IMachineService, MachineManager>();
builder.Services.AddScoped<IMachineDal, EfMachineDal>();
builder.Services.AddScoped<IMachineStatusService, MachineStatusManager>();
builder.Services.AddScoped<IMachineStatusDal, EfMachineStatusDal>();
builder.Services.AddScoped<IShiftService, ShiftManager>();
builder.Services.AddScoped<IShiftDal, EfShiftDal>();
builder.Services.AddScoped<IStatusTypeService, StatusTypeManager>();
builder.Services.AddScoped<IStatusTypeDal, EfStatusTypeDal>();

// CORS - Herkese açýk
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Herhangi bir origin'e izin ver
              .AllowAnyHeader()   // Tüm header'lara izin ver
              .AllowAnyMethod();  // Tüm HTTP metodlarýna izin ver
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware sýralamasý önemli
app.UseCors("AllowAll"); // CORS middleware'i burada kullanýlmalý

// Swagger aktif et (geliþtirme aþamasýnda)
app.UseSwagger();
app.UseSwaggerUI();

// HTTPS yönlendirmesini devre dýþý býrak
// app.UseHttpsRedirection(); // Bu satýrý yorum satýrýna al

app.UseAuthorization(); // Authorization middleware
app.MapControllers();    // Controller mapping

app.Run(); // Uygulamayý baþlat

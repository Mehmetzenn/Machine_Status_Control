using Business.Abstract;
using Business.Abstracts;
using Business.Concrete;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes;

var builder = WebApplication.CreateBuilder(args);

// Uygulaman�n belirtilen IP ve port �zerinden yay�n yapmas�
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

// CORS - Herkese a��k
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()   // Herhangi bir origin'e izin ver
              .AllowAnyHeader()   // T�m header'lara izin ver
              .AllowAnyMethod();  // T�m HTTP metodlar�na izin ver
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware s�ralamas� �nemli
app.UseCors("AllowAll"); // CORS middleware'i burada kullan�lmal�

// Swagger aktif et (geli�tirme a�amas�nda)
app.UseSwagger();
app.UseSwaggerUI();

// HTTPS y�nlendirmesini devre d��� b�rak
// app.UseHttpsRedirection(); // Bu sat�r� yorum sat�r�na al

app.UseAuthorization(); // Authorization middleware
app.MapControllers();    // Controller mapping

app.Run(); // Uygulamay� ba�lat

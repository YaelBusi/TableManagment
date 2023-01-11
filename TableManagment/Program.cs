using BL;
using DL;
using DL.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IBLColor), typeof(BLColor));
builder.Services.AddScoped(typeof(IDLColor), typeof(DLColor));
 
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ColorCollection_2ALLContext>(option => option.UseSqlServer(
     "Server=DESKTOP-MQD9E13;Database=ColorCollection_2ALL;Trusted_Connection=True;"), ServiceLifetime.Scoped);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

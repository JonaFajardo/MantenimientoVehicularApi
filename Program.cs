using Microsoft.EntityFrameworkCore;
using MantenimientoVehicularApi.Models;


var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
builder.Services.AddCors(options => 
{
options.AddPolicy(name: MyAllowSpecificOrigins,
policy =>
 {
     policy .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
            
 });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<MantenimientoVehicularContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ControlVehicularBD")));

 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();
app.MapControllers();
app.Run();

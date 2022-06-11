using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace MantenimientoVehicularApi.Models
{
    public class MantenimientoVehicularContext  : DbContext
    {
        public MantenimientoVehicularContext(DbContextOptions<MantenimientoVehicularContext> options) : base(options)
        {
        }
    public DbSet<Client> Client { get; set; }=null!;
    public DbSet<User> User { get; set; }=null!;
    
    }
}

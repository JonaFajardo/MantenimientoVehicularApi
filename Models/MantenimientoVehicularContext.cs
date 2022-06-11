using Microsoft.EntityFrameworkCore;
using MantenimientoVehicularApi.Models;

namespace MantenimientoVehicularApi.Models
{
    public class MantenimientoVehicularContext  : DbContext
    {
        public MantenimientoVehicularContext(DbContextOptions<MantenimientoVehicularContext> options) : base(options)
        {
        }
    public DbSet<Client> Client { get; set; }=null!;
    public DbSet<User> User { get; set; }=null!;

    public DbSet<car>Car { get; set; }=null!;
    
    
    }
}

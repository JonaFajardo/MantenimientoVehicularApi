namespace MantenimientoVehicularApi.Models
{
public class User
{

public int id { get; set; }
public string? name { get; set; }
public string? lastName { get; set; }
public string userName  { get; set; }= default!;
public string password { get; set; }= default!;
public string? perfil { get; set; }
    
}

}

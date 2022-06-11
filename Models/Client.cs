namespace MantenimientoVehicularApi.Models
{
    public class Client
    {
        public long Id{ get; set; }
        public string? FirstName { get; set; }
        public string? SecondName { get; set; }
        public string? FirstLastName { get; set; }
        public string? SecondLastName { get; set; }
        public string? Identification { get; set; }        
        public bool IsActive { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string? RegisterUser { get; set; }

    }

}
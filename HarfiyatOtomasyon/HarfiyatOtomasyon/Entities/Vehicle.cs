using System.ComponentModel.DataAnnotations;

namespace HarfiyatOtomasyon.Entities
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }
        public string VehicleName { get; set; }
        public string VehiclePrice { get; set; }
        public string VehicleStatus { get; set; }
    }
}

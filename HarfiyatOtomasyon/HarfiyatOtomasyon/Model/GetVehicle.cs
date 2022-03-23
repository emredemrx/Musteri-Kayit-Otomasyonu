using System.Collections.Generic;
using System.Linq;
using HarfiyatOtomasyon.Entities;

namespace HarfiyatOtomasyon.Model
{
    public class GetVehicle
    {
        public List<Vehicle> GetAllVehicle()
        {
            using (DataContext context = new DataContext())
            {
                return context.Vehicle.ToList(); ;
            }
        }
    }
}

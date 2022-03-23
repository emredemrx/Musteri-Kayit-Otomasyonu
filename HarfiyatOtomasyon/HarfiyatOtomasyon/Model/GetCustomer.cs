using System.Collections.Generic;
using System.Linq;
using HarfiyatOtomasyon.Entities;

namespace HarfiyatOtomasyon.Model
{
    public class GetCustomer
    {
        public List<Customer> GetAll()
        {
            using (DataContext context = new DataContext())
            {
                return context.Musteri.ToList(); ;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HarfiyatOtomasyon.Entities;

namespace HarfiyatOtomasyon.Model
{
    public class GetUser
    {
        public List<User> GetAlUsers()
        {
            using (DataContext context = new DataContext())
            {
                return context.User.ToList(); ;
            }
        }
    }
}

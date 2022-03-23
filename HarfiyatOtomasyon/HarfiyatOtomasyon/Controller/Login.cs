using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HarfiyatOtomasyon.Controller
{
    public class Login
    {
        public object loginControl(string name, string password)
        {
            using (DataContext context = new DataContext())
            {
                var controldeger = context.User.Where(w => w.UserName == name && w.UserPassword ==password).FirstOrDefault();
               return controldeger;
            }
        }
    }
}

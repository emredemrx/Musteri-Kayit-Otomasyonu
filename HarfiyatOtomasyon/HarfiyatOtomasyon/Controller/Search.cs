using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarfiyatOtomasyon.Controller
{
    public class Search
    {
        public object CustomerSearch(string aranan, string s)
        {
            if(s == "name")
            {
                using (DataContext context = new DataContext())
                {
                    var controldeger = from e in context.Musteri
                        where e.CustomerFirstName.Contains(aranan)
                        select e;
                    return controldeger.ToList();
                }
            }
            else if(s == "number")
            {
                using (DataContext context = new DataContext())
                {
                    var controldeger = from e in context.Musteri
                        where e.Number.Contains(aranan)
                        select e;
                    return controldeger.ToList();
                }
            }
            else
            {
                using (DataContext context = new DataContext())
                {
                    var controldeger = from e in context.Musteri
                        where e.CustomerAddress.Contains(aranan)
                        select e;
                    return controldeger.ToList();
                }
            }
        }
    }
}

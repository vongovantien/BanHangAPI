using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Entities
{
    public class Supplier
    {
        public int SupplierID { get; set; }
        public string SuplierName { get; set; }
        public ICollection<Product> Products { get; set; }

        public Supplier()
        {
            Products = new List<Product>();
        }
    }
}

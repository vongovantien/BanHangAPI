using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Entities
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }

        public ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Entities
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public int SupplierID { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Entities
{
    public class OrderDetail
    {
        public int ProductID { get; set; }

        public int OrderID { get; set; }
        public decimal UnitPrice { get; set; }
        public double Quantity { get; set; }

        //relationship
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}

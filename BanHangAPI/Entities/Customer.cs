using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Entities
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

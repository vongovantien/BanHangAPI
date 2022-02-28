using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Entities
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ShippedDate { get; set; }

        public string ShipName { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public Customer Customer { get; set; }
        public Employee Employee { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}

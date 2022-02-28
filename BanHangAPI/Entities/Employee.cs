using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Entities
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string EmplployeeName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Order> Orders { get; set; }
        
        public string Title { get; set; }
    }
}

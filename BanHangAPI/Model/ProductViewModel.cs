using BanHangAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Model
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public Supplier Supplier { get; set; }
    }
}

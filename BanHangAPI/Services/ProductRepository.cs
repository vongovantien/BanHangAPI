using BanHangAPI.Data;
using BanHangAPI.Entities;
using BanHangAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDBContext _context;
        public ProductRepository(MyDBContext context)
        {
            _context = context;
        }

        public Product CreateProduct (ProductViewModel product)
        {
            var _product = new Product {
                ProductName = product.ProductName,
                UnitPrice = product.UnitPrice,
                Description = product.Description,
            };
            _context.Add(_product);
            _context.SaveChanges();
            return new Product
            {
                ProductID = product.ProductId,
                ProductName = product.ProductName
            };
        }

        public void DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public ProductViewModel GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(ProductViewModel product)
        {
            throw new NotImplementedException();
        }
    }
}

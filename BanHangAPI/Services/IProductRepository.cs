using BanHangAPI.Data;
using BanHangAPI.Entities;
using BanHangAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Services
{
    public interface IProductRepository
    {
        List<ProductViewModel> GetAll();
        ProductViewModel GetProductById(int id);
        Product CreateProduct (ProductViewModel product);
        void UpdateProduct(ProductViewModel product);
        void DeleteProduct(int id);
    }
}

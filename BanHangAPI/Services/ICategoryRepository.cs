using BanHangAPI.Data;
using BanHangAPI.Entities;
using BanHangAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Services
{
    interface ICategoryRepository
    {
        List<CategoryViewModel> GetAll();
        CategoryViewModel GetById(int id);
        CategoryViewModel Add(Category category );
        CategoryViewModel Update(CategoryViewModel category, int id);
        void Delete(int id);
    }
}

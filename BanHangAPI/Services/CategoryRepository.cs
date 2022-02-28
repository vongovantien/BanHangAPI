using BanHangAPI.Data;
using BanHangAPI.Entities;
using BanHangAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanHangAPI.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDBContext _context;

        public CategoryRepository(MyDBContext context)
        {
            _context = context;
        }
        public CategoryViewModel Add(Category category)
        {
            var loai = new Category
            {
                CategoryName = category.CategoryName
            };

            _context.Add(loai);
            _context.SaveChanges();

            return new CategoryViewModel
            {
                CategoryID = loai.CategoryID,
                CategoryName = loai.CategoryName
            };
        }

        public void Delete(int id)
        {
            var loai = _context.Categories.SingleOrDefault(l => l.CategoryID == id);
            if(loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            };
        }

        public List<CategoryViewModel> GetAll()
        {
            var loais = _context.Categories.Select(l => new CategoryViewModel
            {
                CategoryID = l.CategoryID,
                CategoryName = l.CategoryName
            }).ToList();

            return loais;
        }

        public CategoryViewModel GetById(int id)
        {
            var loai = _context.Categories.SingleOrDefault(l => l.CategoryID == id);
            if(loai != null)
            {
                return new CategoryViewModel
                {
                    CategoryID = loai.CategoryID,
                    CategoryName = loai.CategoryName
                };
            }
            return null;
        }

        public CategoryViewModel Update(CategoryViewModel category, int id)
        {
            var loai = _context.Categories.SingleOrDefault(l => l.CategoryID == id);
            loai.CategoryName = category.CategoryName;
            _context.SaveChanges();
            return new CategoryViewModel
            {
                CategoryID = loai.CategoryID,
                CategoryName = loai.CategoryName
            };
        }
    }
}

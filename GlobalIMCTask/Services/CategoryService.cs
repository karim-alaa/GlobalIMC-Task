using GlobalIMCTask.Data;
using GlobalIMCTask.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalIMCTask.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetFirstCategory();
        Task<Category> GetCategoryWithProduct(Guid CategoryId);
        Task<Category> CreateCategory(Category category);
    }

    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;

        public CategoryService(DataContext context)
        {
            _context = context;
        }


        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Categories
                        .AsNoTracking()
                        .ToListAsync();
        }

        public async Task<Category> GetFirstCategory()
        {
            return await _context.Categories
                        .Include(c => c.Products)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
        }


        public async Task<Category> GetCategoryWithProduct(Guid CategoryId)
        {
            return await _context.Categories
                        .Where(c => c.Id == CategoryId)
                        .Include(c => c.Products)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();
        }


        public async Task<Category> CreateCategory(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();

            // with auto-generated ID
            return category;
        }
    }
}

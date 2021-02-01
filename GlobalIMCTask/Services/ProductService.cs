using GlobalIMCTask.Data;
using GlobalIMCTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalIMCTask.Services
{
    public interface IProductService
    {
        Task<Product> CreateProduct(Product product);
    }

    public class ProductService : IProductService
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            // with auto-generated code
            return product;
        }
    }
}

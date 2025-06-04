using Microsoft.EntityFrameworkCore;
using sql.Data.Context;
using sql.Model;
using System;

namespace sql.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SqlDbContext _context;

        public ProductRepository(SqlDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is null) return;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}

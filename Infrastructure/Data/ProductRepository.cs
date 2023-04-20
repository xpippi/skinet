using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IproductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            this._context = context;
        }


        public async Task<Product> GetProductByIdAsync(int id)
        {
             return await _context.Products
             .Include(p => p.ProductType)
             .Include(p => p.ProductBrand)
             .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductByAsync()
        {
            return await _context.Products
            .Include(p => p.ProductType)
            .Include(p => p.ProductBrand)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsByAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypeByAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
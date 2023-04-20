using Core.Entities;

namespace Core.Interfaces
{
    public interface IproductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
            
        Task<IReadOnlyList<Product>> GetProductByAsync();

        Task<IReadOnlyList<ProductBrand>> GetProductBrandsByAsync();

        Task<IReadOnlyList<ProductType>> GetProductTypeByAsync();


    }
}
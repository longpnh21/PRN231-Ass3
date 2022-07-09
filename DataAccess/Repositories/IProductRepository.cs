using BusinessObject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IProductRepository
    {
        Task DeleteProductAsync(Product product);
        Task<Product> FindProductByIdAsync(int id);
        Task<List<Product>> GetProductsAsync();
        Task SaveProductAsync(Product product);
        Task UpdateProductAsync(Product product);
    }
}
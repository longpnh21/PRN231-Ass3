using BusinessObject.Entities;
using DataAccess.Daos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task DeleteProductAsync(Product product) => await ProductDAO.DeleteProductAsync(product);

        public async Task<Product> FindProductByIdAsync(int id) => await ProductDAO.FindProductByIdAsync(id);

        public async Task<List<Product>> GetProductsAsync() => await ProductDAO.GetProducts();

        public async Task SaveProductAsync(Product product) => await ProductDAO.SaveProductAsync(product);

        public async Task UpdateProductAsync(Product product) => await ProductDAO.UpdateProductAsync(product);
    }
}
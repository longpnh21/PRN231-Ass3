using BusinessObject;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Daos
{
    public class ProductDAO
    {
        private static ProductDAO instance = null;
        private static readonly object instanceLock = new();

        public static ProductDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ProductDAO();
                    }
                }
                return instance;
            }
        }

        public async static Task<List<Product>> GetProducts()
        {
            List<Product> products;
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    products = await dbContext.Products.AsNoTracking().Include(e => e.Category).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return products;
        }

        public async static Task<Product> FindProductByIdAsync(int id)
        {
            var product = new Product();
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    product = await dbContext.Products.AsNoTracking().Include(e => e.Category).FirstOrDefaultAsync(e => e.ProductId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return product;
        }

        public async static Task SaveProductAsync(Product product)
        {
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    await dbContext.Products.AddAsync(product);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async static Task UpdateProductAsync(Product product)
        {
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async static Task DeleteProductAsync(Product product)
        {
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    var c = await dbContext.Products.FirstOrDefaultAsync(e => e.ProductId.Equals(product.ProductId));
                    if (c != null)
                    {
                        dbContext.Products.Remove(c);
                    }
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

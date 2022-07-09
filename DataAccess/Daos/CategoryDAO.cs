using BusinessObject;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Daos
{
    public class CategoryDAO
    {
        private static CategoryDAO instance = null;
        private static readonly object instanceLock = new();

        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new CategoryDAO();
                    }
                }
                return instance;
            }
        }

        public async static Task<List<Category>> GetCategoriesAsync()
        {
            List<Category> categories;
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    categories = await dbContext.Categories.AsNoTracking().ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return categories;
        }

        public async static Task<Category> FindCategoryByIdAsync(int id)
        {
            var category = new Category();
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    category = await dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(e => e.CategoryId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return category;
        }

        public async static Task SaveCategoryAsync(Category category)
        {
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    await dbContext.Categories.AddAsync(category);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async static Task UpdateCategoryAsync(Category category)
        {
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Entry(category).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async static Task DeleteCategoryAsync(Category category)
        {
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    var c = await dbContext.Categories.FirstOrDefaultAsync(e => e.CategoryId.Equals(category.CategoryId));
                    if (c != null)
                    {
                        dbContext.Categories.Remove(c);
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

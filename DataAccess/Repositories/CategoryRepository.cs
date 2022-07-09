using BusinessObject.Entities;
using DataAccess.Daos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public async Task DeleteCategoryAsync(Category category) => await CategoryDAO.DeleteCategoryAsync(category);

        public async Task<Category> FindCategoryByIdAsync(int id) => await CategoryDAO.FindCategoryByIdAsync(id);

        public async Task<List<Category>> GetCategoriesAsync() => await CategoryDAO.GetCategoriesAsync();

        public async Task SaveCategoryAsync(Category category) => await CategoryDAO.SaveCategoryAsync(category);

        public async Task UpdateCategoryAsync(Category category) => await CategoryDAO.UpdateCategoryAsync(category);
    }
}

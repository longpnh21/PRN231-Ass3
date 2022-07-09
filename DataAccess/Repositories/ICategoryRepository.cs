using BusinessObject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface ICategoryRepository
    {
        Task DeleteCategoryAsync(Category category);
        Task<Category> FindCategoryByIdAsync(int id);
        Task<List<Category>> GetCategoriesAsync();
        Task SaveCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
    }
}
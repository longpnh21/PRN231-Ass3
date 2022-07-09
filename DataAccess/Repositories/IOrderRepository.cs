using BusinessObject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IOrderRepository
    {
        Task DeleteOrderAsync(Order order);
        Task<Order> FindOrderByIdAsync(int id);
        Task<List<Order>> GetOrdersAsync();
        Task SaveOrderAsync(Order order);
        Task UpdateOrderAsync(Order order);
    }
}
using BusinessObject.Entities;
using DataAccess.Daos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public async Task DeleteOrderAsync(Order order) => await OrderDAO.DeleteOrderAsync(order);

        public async Task<Order> FindOrderByIdAsync(int id) => await OrderDAO.FindOrderByIdAsync(id);

        public async Task<List<Order>> GetOrdersAsync() => await OrderDAO.GetOrdersAsync();

        public async Task SaveOrderAsync(Order order) => await OrderDAO.SaveOrderAsync(order);

        public async Task UpdateOrderAsync(Order order) => await OrderDAO.UpdateOrderAsync(order);
    }
}
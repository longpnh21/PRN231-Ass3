using BusinessObject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public interface IOrderDetailRepository
    {
        Task DeleteOrderDetailAsync(OrderDetail product);
        Task<OrderDetail> FindOrderDetailByIdAsync(int orderId, int productId);
        Task<List<OrderDetail>> GetOrderDetailsAsync();
        Task SaveOrderDetailAsync(OrderDetail product);
        Task UpdateOrderDetailAsync(OrderDetail product);
    }
}
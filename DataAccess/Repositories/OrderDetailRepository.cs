using BusinessObject.Entities;
using DataAccess.Daos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public async Task DeleteOrderDetailAsync(OrderDetail product) => await OrderDetailDAO.DeleteOrderDetailAsync(product);

        public async Task<OrderDetail> FindOrderDetailByIdAsync(int orderId, int productId) => await OrderDetailDAO.FindOrderDetailByIdAsync(orderId, productId);

        public async Task<List<OrderDetail>> GetOrderDetailsAsync() => await OrderDetailDAO.GetOrderDetailsAsync();

        public async Task SaveOrderDetailAsync(OrderDetail product) => await OrderDetailDAO.SaveOrderDetailAsync(product);

        public async Task UpdateOrderDetailAsync(OrderDetail product) => await OrderDetailDAO.UpdateOrderDetail(product);
    }
}
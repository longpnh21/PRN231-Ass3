using BusinessObject;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Daos
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO instance = null;
        private static readonly object instanceLock = new();

        public static OrderDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDetailDAO();
                    }
                }
                return instance;
            }
        }

        public async static Task<List<OrderDetail>> GetOrderDetailsAsync()
        {
            List<OrderDetail> orderDetails;
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    orderDetails = await dbContext.OrderDetails.AsNoTracking().ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetails;
        }

        public async static Task<OrderDetail> FindOrderDetailByIdAsync(int orderId, int productId)
        {
            var orderDetail = new OrderDetail();
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    orderDetail = await dbContext.OrderDetails.AsNoTracking().FirstOrDefaultAsync(e => e.OrderId == orderId && e.ProductId == productId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orderDetail;
        }

        public async static Task SaveOrderDetailAsync(OrderDetail orderDetail)
        {
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    await dbContext.OrderDetails.AddAsync(orderDetail);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async static Task UpdateOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Entry(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async static Task DeleteOrderDetailAsync(OrderDetail orderDetail)
        {
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    var c = dbContext.OrderDetails.FirstOrDefault(e => e.OrderId == orderDetail.OrderId && e.ProductId == orderDetail.ProductId);
                    if (c != null)
                    {
                        dbContext.OrderDetails.Remove(c);
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

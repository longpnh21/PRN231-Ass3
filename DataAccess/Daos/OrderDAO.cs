using BusinessObject;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Daos
{
    public class OrderDAO
    {
        private static OrderDAO instance = null;
        private static readonly object instanceLock = new();

        public static OrderDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new OrderDAO();
                    }
                }
                return instance;
            }
        }

        public async static Task<List<Order>> GetOrdersAsync()
        {
            List<Order> orders;
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    orders = await dbContext.Orders.AsNoTracking().ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return orders;
        }

        public async static Task<Order> FindOrderByIdAsync(int id)
        {
            var order = new Order();
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    order = await dbContext.Orders.AsNoTracking().Include(e => e.OrderDetails).ThenInclude(d => d.Product).FirstOrDefaultAsync(e => e.OrderId == id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return order;
        }

        public async static Task SaveOrderAsync(Order order)
        {
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    await dbContext.Orders.AddAsync(order);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async static Task UpdateOrderAsync(Order order)
        {
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    dbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async static Task DeleteOrderAsync(Order order)
        {
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    var c = dbContext.Orders.FirstOrDefault(e => e.OrderId.Equals(order.OrderId));
                    if (c != null)
                    {
                        dbContext.Orders.Remove(c);
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

using BusinessObject;
using BusinessObject.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Daos
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private static readonly object instanceLock = new();

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                }
                return instance;
            }
        }

        public async static Task<List<User>> GetUsersAsync()
        {
            List<User> users;
            try
            {
                using (var dbContext = new MyDbContext())
                {
                    users = await dbContext.Users.ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return users;
        }
    }
}

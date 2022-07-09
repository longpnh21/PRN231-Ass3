using BusinessObject.Entities;
using DataAccess.Daos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> GetUsersAsync() => await UserDAO.GetUsersAsync();
    }
}

using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Abstract
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task DeleteUser(int id);
    }
}

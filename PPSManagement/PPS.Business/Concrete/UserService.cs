using PPS.Business.Abstract;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.Business.Concrete
{
    public class UserService : IUserService
    {
        protected IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
      
        public async Task<List<User>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }
        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);
        }
        public async Task<User> CreateUser(User user)
        {
            return await _userRepository.CreateUser(user);
        }
        public async Task<User> UpdateUser(User user)
        {
            return await _userRepository.UpdateUser(user);
        }
        public async Task DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
        }
    }
}

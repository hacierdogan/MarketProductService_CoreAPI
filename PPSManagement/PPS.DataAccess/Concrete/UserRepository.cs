using Microsoft.EntityFrameworkCore;
using PPS.DataAccess.Abstract;
using PPS.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PPS.DataAccess.Concrete
{
    public class UserRepository : IUserRepository
    {
        public async Task<List<User>> GetAllUsers()
        {
            using(var db=new DataContext())
            {
                return await db.Users.ToListAsync();
            }
        }
        public async Task<User> GetUserById(int id)
        {
            using (var db = new DataContext())
            {
                return await db.Users.FindAsync(id);
            }
        }
        public async Task<User> CreateUser(User user)
        {
            using (var db = new DataContext())
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return user;
            }
        }
        public async Task<User> UpdateUser(User user)
        {
            using (var db = new DataContext())
            {
                db.Users.Update(user);
                await db.SaveChangesAsync();
                return user;
            }
        }
        public async Task DeleteUser(int id)
        {
            using (var db = new DataContext())
            {
                var deleteUser = await GetUserById(id);
                db.Users.Remove(deleteUser);
                await db.SaveChangesAsync();
            }
        }

    }
}

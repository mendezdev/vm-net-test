using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserActions
{
    public class UserAction : IUserAction
    {
        private readonly VirtualMindContext context;

        public UserAction()
        {
            context = new VirtualMindContext();
        }

        public async Task<User> Create(User user)
        {
            context.Users.Add(user);
            var result = await context.SaveChangesAsync();
            return user;
        }

        public Task<List<User>> GetAll()
        {
            return context.Users.ToListAsync();
        }

        public Task<User> GetById(int id)
        {
            return context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> Update(int id, User user)
        {
            var existingUser = await context.Users.SingleOrDefaultAsync(u => u.Id == id);

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            var result = await context.SaveChangesAsync();
            return existingUser;
        }
    }
}

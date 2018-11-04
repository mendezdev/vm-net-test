using Core.UserException;
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

        public async Task<User> GetById(int id)
        {
            var user = await context.Users.SingleOrDefaultAsync(u => u.Id == id);
            if (user == null)
                throw new UserIdNotFoundException($"No existe un usuario con el id {id}");

            return user;
        }

        public async Task<User> Update(int id, User user)
        {
            var existingUser = await context.Users.SingleOrDefaultAsync(u => u.Id == id);
            
            if (existingUser == null)
                throw new UserIdNotFoundException($"No existe un usuario con el id {id}");

            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            var result = await context.SaveChangesAsync();
            return existingUser;
        }
    }
}

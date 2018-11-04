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
    }
}

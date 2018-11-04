using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.UserActions;
using ViewModels;

namespace Domain.Impl
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserAction userAction;

        public UserDomain()
        {
            userAction = new UserAction();
        }

        public async Task<User> Create(User user)
        {
            return await userAction.Create(user);
        }

        public async Task<List<UserResponse>> GetAll()
        {
            var users = await userAction.GetAll();
            return users.Select(u => new UserResponse
            {
                Id = u.Id,
                Email = u.Email,
                FirstName = u.FirstName,
                LastName = u.LastName
            }).ToList();
        }
    }
}

using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.UserActions;
using ViewModels;
using Domain.Impl.Formatters;

namespace Domain.Impl
{
    public class UserDomain : IUserDomain
    {
        private readonly IUserAction userAction;
        private readonly UserFormatter userFormatter;

        public UserDomain()
        {
            userAction = new UserAction();
            userFormatter = new UserFormatter();
        }

        public async Task<User> Create(User user)
        {
            return await userAction.Create(user);
        }

        public async Task<List<UserResponse>> GetAll()
        {
            var users = await userAction.GetAll();
            return users.Select(u => userFormatter.ToUserResponse(u)).ToList();
        }

        public async Task<UserResponse> GetById(string id)
        {
            var user = await userAction.GetById(Convert.ToInt32(id));
            return userFormatter.ToUserResponse(user);
        }

        public async Task<UserResponse> Update(string id, User user)
        {
            var userUpdated = await userAction.Update(Convert.ToInt32(id), user);
            return userFormatter.ToUserResponse(userUpdated);
        }
    }
}

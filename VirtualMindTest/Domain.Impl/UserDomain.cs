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

        public UserDomain(IUserAction userAction)
        {
            this.userAction = userAction;
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

        public async Task<UserResponse> GetById(int id)
        {
            var user = await userAction.GetById(id);
            return userFormatter.ToUserResponse(user);
        }

        public async Task<UserResponse> Update(int id, User user)
        {
            var userUpdated = await userAction.Update(id, user);
            return userFormatter.ToUserResponse(userUpdated);
        }

        public async Task Delete(int id)
        {
            await userAction.Delete(id);
        }
    }
}

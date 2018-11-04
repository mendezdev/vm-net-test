using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Domain
{
    public interface IUserDomain
    {
        Task<User> Create(User user);
        Task<List<UserResponse>> GetAll();
    }
}

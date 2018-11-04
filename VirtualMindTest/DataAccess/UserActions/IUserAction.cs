using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.UserActions
{
    public interface IUserAction
    {
        Task<User> Create(User user);
        Task<List<User>> GetAll();
        Task<User> GetById(int id);
        Task<User> Update(int id, User user);
    }
}

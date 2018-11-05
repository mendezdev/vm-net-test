using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.User
{
    public class UserFakeData
    {
        public List<Models.User> GetAllUsersModel()
        {
            return new List<Models.User>
            {
                new Models.User { Id=1, FirstName="Pablo", LastName="Mendez", Email="pablo@mail.com", Password="1234" },
                new Models.User { Id=2, FirstName="Sergio", LastName="Alsamendi", Email="sergia@mail.com", Password="1234" }
            };
        }

        public Models.User GetCreatedUser()
        {
            return GetAllUsersModel()[0];
        }        
    }
}

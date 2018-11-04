using Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class VirtualMindInitializer : DropCreateDatabaseIfModelChanges<VirtualMindContext>
    {
        protected override void Seed(VirtualMindContext context)
        {
            var users = new List<User>
            {
                new User { FirstName = "Pablo", LastName="Mendez", Email="mendez.developer@gmail.com", Password="1234" },
                new User { FirstName = "Virtual", LastName="Mind", Email="admin@gvirtualmind.com", Password="1234" }
            };

            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();
        }
    }
}

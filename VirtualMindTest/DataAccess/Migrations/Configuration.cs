namespace DataAccess.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccess.VirtualMindContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "DataAccess.VirtualMindContext";
        }

        protected override void Seed(DataAccess.VirtualMindContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
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

using System;
using System.Threading.Tasks;
using GrabrReplica.Common;
using GrabrReplica.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Internal;

namespace GrabrReplica.Persistance
{
    public class ApplicationDbInitializer
    {
        public static void Initialize(ApplicationDbContext context, RoleManager<Role> roleManager)
        {
            var initializer = new ApplicationDbInitializer();
            initializer.SeedEverything(context, roleManager);
        }

        private void SeedEverything(ApplicationDbContext context, RoleManager<Role> roleManager)
        {
            context.Database.EnsureCreated();

            if (!context.Roles.Any())
            {
                SeedRoles(context, roleManager);
            }
        }

        private void SeedRoles(ApplicationDbContext context, RoleManager<Role> roleManager)
        {
            roleManager.CreateAsync(new Role(UserRoleNames.User)).GetAwaiter().GetResult();
            roleManager.CreateAsync(new Role(UserRoleNames.Admin)).GetAwaiter().GetResult();
        }
    }
}
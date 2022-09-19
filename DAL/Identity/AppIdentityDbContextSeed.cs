using Core.Entities;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GetGroup.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            if (roleManager.Roles.Count() == 0 && userManager.Users.Count() == 0)
            {
                var user = new AppUser
                {
                    UserName = "SuperAdmin",
                    Email = "Kamal@Gmail.com",
                    EmailConfirmed = true,
                };

              await userManager.CreateAsync(user, "P@ssw0rd");
            }

        }
    }
}

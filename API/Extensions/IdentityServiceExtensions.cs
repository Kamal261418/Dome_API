using System.Text;
using Core.Entities;
using Core.Entities.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services,
            IConfiguration config)
        {
            var builder = services.AddIdentity<AppUser, IdentityRole<int>>();
            builder = new IdentityBuilder(builder.UserType,builder.RoleType, builder.Services);
            builder.AddEntityFrameworkStores<AppIdentityDbContext>();
            builder.AddDefaultTokenProviders();
            builder.AddSignInManager<SignInManager<AppUser>>();
            builder.AddRoleManager<RoleManager<IdentityRole<int>>>();
          

            return services;
        }
    }
}



using Microsoft.Extensions.DependencyInjection;
using Sadvo.Application.Interfaces;
using Sadvo.Application.Services;
using Sadvo.Persistence.InterfacesRepositories.ISecurity;
using Sadvo.Persistence.Repositories.SecurityR;

namespace Sadvo.IOC.Dependancies
{
    public static class UsersDependancy
    {
        public static void AddUsersDependancy(this IServiceCollection services)
        {
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddTransient<IUserServices, UsersService>();
        }
    }
}

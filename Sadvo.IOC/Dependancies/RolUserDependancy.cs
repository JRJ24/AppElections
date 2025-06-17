using Microsoft.Extensions.DependencyInjection;
using Sadvo.Application.Interfaces;
using Sadvo.Application.Services;
using Sadvo.Persistence.InterfacesRepositories.ISecurity;
using Sadvo.Persistence.Repositories.SecurityR;


namespace Sadvo.IOC.Dependancies
{
    public static class RolUserDependancy
    {
        public static void AddRolUserDependancy(this IServiceCollection services)
        {
            services.AddScoped<IRolUsersRepository, RolUsersRepository>();
            services.AddTransient<IRolUserService, RolUserServices>();
        }
    }
}

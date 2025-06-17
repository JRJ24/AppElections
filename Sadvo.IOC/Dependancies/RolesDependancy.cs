

using Microsoft.Extensions.DependencyInjection;
using Sadvo.Application.Interfaces;
using Sadvo.Application.Services;
using Sadvo.Persistence.InterfacesRepositories.ISecurity;
using Sadvo.Persistence.Repositories.SecurityR;

namespace Sadvo.IOC.Dependancies
{
    public static class RolesDependancy
    {
        public static void AddRolesDependancy(this IServiceCollection services)
        {
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddTransient<IRolService, RolServices>();
        }
    }
}

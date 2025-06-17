

using Microsoft.Extensions.DependencyInjection;
using Sadvo.Application.Interfaces;
using Sadvo.Application.Services;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;
using Sadvo.Persistence.Repositories.ConfigurationR;

namespace Sadvo.IOC.Dependancies
{
    public static class ElectivePositionsDependancy
    {
        public static void AddElectivePositionsDependancy(this IServiceCollection services)
        {
            services.AddScoped<IElectivePositionsRepository, ElectivePositionsRepository>();
            services.AddTransient<IElectivePositionsServices, ElectivePositionsService>();
        }
    }
}

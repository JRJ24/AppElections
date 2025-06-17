

using Microsoft.Extensions.DependencyInjection;
using Sadvo.Application.Interfaces;
using Sadvo.Application.Services;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;
using Sadvo.Persistence.Repositories.ConfigurationR;

namespace Sadvo.IOC.Dependancies
{
    public static class AliancePoliticalDependancy
    {
        public static void AddAliancePoliticalDependancy(this IServiceCollection services)
        {
            services.AddScoped<IAliancePoliticalRepository, AliancePoliticalRepository>();
            services.AddTransient<IAliancePoliticalService, AliancePoliticalService>();
        }
    }
}

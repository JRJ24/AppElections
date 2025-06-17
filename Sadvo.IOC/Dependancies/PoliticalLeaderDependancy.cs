

using Microsoft.Extensions.DependencyInjection;
using Sadvo.Application.Interfaces;
using Sadvo.Application.Services;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;
using Sadvo.Persistence.Repositories.ConfigurationR;

namespace Sadvo.IOC.Dependancies
{
    public static class PoliticalLeaderDependancy
    {
        public static void AddPoliticalLeaderDependancy(this IServiceCollection services)
        {
            services.AddScoped<IPoliticalLeaderRepository, PoliticalLeaderRepository>();
            services.AddTransient<IPoliticalLeaderServices, PoliticalLeaderService>();
        }
    }
}

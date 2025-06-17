

using Microsoft.Extensions.DependencyInjection;
using Sadvo.Application.Interfaces;
using Sadvo.Application.Services;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;
using Sadvo.Persistence.Repositories.ConfigurationR;

namespace Sadvo.IOC.Dependancies
{
    public static class PartyPoliticalDependancy
    {
        public static void AddPartyPoliticalDependancy(this IServiceCollection services)
        {
            services.AddScoped<IPartyPoliticalRepository, PartyPoliticalRepository>();
            services.AddTransient<IPartyPoliticalService, PartyPoliticalService>();
        }
    }
}

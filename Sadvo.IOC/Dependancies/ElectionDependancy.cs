

using Microsoft.Extensions.DependencyInjection;
using Sadvo.Application.Interfaces;
using Sadvo.Application.Services;
using Sadvo.Persistence.InterfacesRepositories.IElections;
using Sadvo.Persistence.Repositories.ElectionsR;

namespace Sadvo.IOC.Dependancies
{
    public static class ElectionDependancy
    {
        public static void AddElectionDependancy(this IServiceCollection services)
        {
            services.AddScoped<IElectionRepository, ElectionRepository>();
            services.AddTransient<IElectionService, ElectionService>();
        }
    }
}

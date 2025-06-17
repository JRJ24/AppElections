

using Microsoft.Extensions.DependencyInjection;
using Sadvo.Application.Interfaces;
using Sadvo.Application.Services;
using Sadvo.Persistence.InterfacesRepositories.IElections;
using Sadvo.Persistence.Repositories.ElectionsR;

namespace Sadvo.IOC.Dependancies
{
    public static class CitizensDependancy
    {
        public static void AddCitizensDepedancy(this IServiceCollection services)
        {
            services.AddScoped<ICitizenRepository, CitizenRepository>();
            services.AddTransient<ICitizensServices, CitizensService>();
        }
    }
}

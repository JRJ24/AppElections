

using Microsoft.Extensions.DependencyInjection;
using Sadvo.Application.Interfaces;
using Sadvo.Application.Services;
using Sadvo.Persistence.InterfacesRepositories.IConfiguration;
using Sadvo.Persistence.Repositories.ConfigurationR;

namespace Sadvo.IOC.Dependancies
{
    public static class CandidatosDependancy
    {
        public static void AddCandidatosDependancy(this IServiceCollection services)
        {
            services.AddScoped<ICandidatosRepository, CandidatosRepository>();
            services.AddTransient<ICandidatosServices, CandidatosServices>();
        }
    }
}



using Microsoft.Extensions.DependencyInjection;
using Sadvo.Application.Mappings;
using System.Reflection;

namespace Sadvo.IOC.Dependancies
{
    public static class AutoMapperDependancy
    {
        public static void AddAutoMapperDependancy(this IServiceCollection services) 
        {
            services.AddAutoMapper((Assembly)Assembly.GetAssembly(typeof(AutoMapperProfile)));
        }
    }
}

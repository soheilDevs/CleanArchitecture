using CleanArch.Application.Interfaces;
using CleanArch.Application.Services;
using CleanArch.Domains.Interfaces;
using CleanArch.Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection service)
        {
            //Application Layer 
            service.AddScoped<ICourseService, CourseService>();

            //infra Data Layer
            service.AddScoped<ICourseRepository, CourseRepository>();

        }
    }
}
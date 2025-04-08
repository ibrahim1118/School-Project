using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Services.Abstract;
using SchoolProject.Services.implementation;

namespace SchoolProject.Services
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServicesDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudnetService>();
            services.AddTransient<IDepartmentServices, DepartmentServices>();
            return services; 
        }
    }
}

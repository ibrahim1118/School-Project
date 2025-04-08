using Microsoft.Extensions.DependencyInjection;
using SchoolProject.infrastructure.Abstract;
using SchoolProject.infrastructure.InfrastructureBases;
using SchoolProject.infrastructure.Repositores;
using System.Runtime.CompilerServices;

namespace SchoolProject.infrastructure
{
    public static class ModuleInfrastructureDependencies
    {

        public static IServiceCollection AddInfrastructureDepdndencies(this IServiceCollection services)
        {

            services.AddTransient<IStudentRepo, StudentRepo>();
            services.AddTransient<IDepartmentRepo, DepartmentRepo>();
            services.AddTransient<IInstractorRepo, InstractorRep>();
            services.AddTransient<ISubjectRepo, SubjectRepo>();

            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            return services;
        }
    }
}

using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behiover;
using SchoolProject.Services.Abstract;
using SchoolProject.Services.implementation;
using System.Reflection;

namespace SchoolProject.Core
{
    public static class ModuleCroesDependencies
    {

        public static IServiceCollection AddCoresDependencies(this IServiceCollection services)
        {
            services.AddMediatR(op => op.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            // 
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}

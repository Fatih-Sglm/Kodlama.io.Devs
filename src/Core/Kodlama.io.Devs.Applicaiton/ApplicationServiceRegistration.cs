using Core.Application.Pipelines.Validation;
using FluentValidation;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Rules;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kodlama.io.Devs.Applicaiton
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ProgramingLanguageBussinesRules>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;

        }
    }
}

using Autofac;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.Logger;
using Core.Security.EmailAuthenticator;
using Core.Security.JWT;
using Core.Security.OtpAuthenticator;
using Core.Security.OtpAuthenticator.OtpNet;
using Kodlama.io.Devs.Applicaiton;
using Kodlama.io.Devs.Applicaiton.Abstractions.Services;
using Kodlama.io.Devs.Infrastructure.Service;
using Kodlama.io.Devs.Persistence.Contexts;
using MediatR;
using MediatR.Extensions.Autofac.DependencyInjection;
using System.Reflection;
using Module = Autofac.Module;

namespace Kodlama.io.Devs.WebApi.Configuration.AuotFac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var PersistenceAssmbly = Assembly.GetAssembly(typeof(KodlamaIoDevsContext));
            var ApplicationAssembly = Assembly.GetAssembly(typeof(ApplicationServiceRegistration));

            builder.RegisterAssemblyTypes(PersistenceAssmbly)
                .Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(PersistenceAssmbly)
                .Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            var val = builder.RegisterAssemblyTypes(ApplicationAssembly).Where(x => x.Name.EndsWith("Profiles")).As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg =>
            {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>().CreateMapper(c.Resolve)).As<IMapper>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ApplicationAssembly).Where(x => x.Name.EndsWith("BusinessRules")).InstancePerLifetimeScope();

            builder.RegisterMediatR(ApplicationAssembly);



            builder.RegisterType<FileLogger>()
              .As<LoggerServiceBase>()
              .InstancePerLifetimeScope();

            //builder.RegisterType<UserOperationClaimService>()
            //  .As<IUserOperationClaimService>()
            //  .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(AuthorizationBehavior<,>)).As((typeof(IPipelineBehavior<,>))).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As((typeof(IPipelineBehavior<,>))).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(CachingBehavior<,>)).As((typeof(IPipelineBehavior<,>))).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(CacheRemovingBehavior<,>)).As((typeof(IPipelineBehavior<,>))).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(RequestValidationBehavior<,>)).As((typeof(IPipelineBehavior<,>))).InstancePerLifetimeScope();



            builder.RegisterType<JwtHelper>().As<ITokenHelper>().InstancePerLifetimeScope();
            builder.RegisterType<EmailAuthenticatorHelper>().As<IEmailAuthenticatorHelper>().InstancePerLifetimeScope();
            builder.RegisterType<OtpNetOtpAuthenticatorHelper>().As<IOtpAuthenticatorHelper>().InstancePerLifetimeScope();

            builder.RegisterType<AuthService>().As<IAuthService>().InstancePerLifetimeScope();





        }
    }
}

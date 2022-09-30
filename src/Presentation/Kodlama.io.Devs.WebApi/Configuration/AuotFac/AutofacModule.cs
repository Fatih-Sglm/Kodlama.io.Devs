using Autofac;
using Kodlama.io.Devs.Applicaiton;
using Kodlama.io.Devs.Persistence.Contexts;
using System.Reflection;
using Module = Autofac.Module;

namespace Kodlama.io.Devs.WebApi.Configuration.AutoFac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assm = Assembly.GetAssembly(typeof(KodlamaIoDevsContext));
            builder.RegisterAssemblyTypes(assm).Where
                (x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

            var appAsm = typeof(ApplicationServiceRegistration).Assembly;
            builder.RegisterAssemblyTypes(appAsm).Where(x => x.Name.EndsWith("BusinessRules")).InstancePerLifetimeScope();

        }
    }
}

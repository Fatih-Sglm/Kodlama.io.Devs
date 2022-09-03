using Kodlama.io.Devs.Applicaiton.Services.Repositories;
using Kodlama.io.Devs.Persistence.Contexts;
using Kodlama.io.Devs.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kodlama.io.Devs.Persistence
{
    public static class PersitenceServiceConfiguration
    {

        public static IServiceCollection PersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<KodlamaIoDevsContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("MSS")));
            services.AddScoped<IProgramingLanguageRepository, ProgramingLanguageRepository>();
            return services;
        }
    }
}

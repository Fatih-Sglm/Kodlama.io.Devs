using Core.Application.Pipelines.Caching;
using ServiceStack.Redis;
using StackExchange.Redis;

namespace Kodlama.io.Devs.WebApi.Configuration.ServiceRegistration
{
    public static class RedisConfig
    {
        public static void RedisConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var _redis = configuration.GetSection("Redis").Get<RedisImplementation>();
            services.AddStackExchangeRedisCache(opt =>
            {
                opt.ConfigurationOptions = new ConfigurationOptions()
                {
                    EndPoints =
                    {
                        { _redis.EndPoint, _redis.PortNumber }
                    },
                    Password = _redis.Password,
                    User = _redis.UserName

                };
            });

            services.AddSingleton(opt =>
            {
                return new RedisEndpoint
                {
                    Host = _redis.EndPoint,
                    Port = _redis.PortNumber,
                    Username = _redis.UserName,
                    Password = _redis.Password,
                };
            });
        }
    }
}

using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Application.Pipelines.Caching;
using Kodlama.io.Devs.Applicaiton.Features.ProgramingLanguages.Command.CreateCommand;
using Kodlama.io.Devs.Persistence.Contexts;
using Kodlama.io.Devs.WebApi.Configuration.AuotFac;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ServiceStack.Redis;
using StackExchange.Redis;
using System.Net;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel((context, options) =>
{
    options.Listen(IPAddress.Any, 7140, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1AndHttp2AndHttp3;
        //listenOptions.Protocols = HttpProtocols.Http3;
        listenOptions.UseHttps(/*Http3Certificate.GenerateManualCertificate()*/);
    });
});



builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new AutofacModule()));
builder.Services.AddDbContext<KodlamaIoDevsContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MSS")));
builder.Services.AddDistributedMemoryCache();
builder.Services.AddControllers();
builder.Services.AddMediatR(Assembly.GetAssembly(typeof(CreateProgramingLanguageCommand)));
//builder.Services.PersistenceServices(builder.Configuration);
//builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();

var _redis = builder.Configuration.GetSection("Redis").Get<RedisImplementation>();
builder.Services.AddStackExchangeRedisCache(opt =>
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

builder.Services.AddSingleton(opt =>
{
    return new RedisEndpoint
    {
        Host = _redis.EndPoint,
        Port = _redis.PortNumber,
        Username = _redis.UserName,
        Password = _redis.Password,
    };
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
          .AddJwtBearer(options =>
          {
              options.TokenValidationParameters = new TokenValidationParameters
              {
                  ValidateIssuer = true,
                  ValidateAudience = true,
                  ValidateLifetime = true,
                  ValidateIssuerSigningKey = true,
                  ValidIssuer = builder.Configuration["TokenOptions:Issuer"],
                  ValidAudience = builder.Configuration["TokenOptions:Audience"],
                  IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenOptions:SecurityKey"]))
              };
          });
//builder.Services.AddSecurityServices();
builder.Services.AddAuthorization(options =>
{
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//if (app.Environment.IsProduction())
//app.ConfigureCustomExceptionMiddleware();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();

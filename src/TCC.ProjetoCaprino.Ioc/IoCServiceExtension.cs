using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Minio;
using System.Net;
using TCC.ProjetoCaprino.Domain.Services;
using TCC.ProjetoCaprino.Data.Services;
using TCC.ProjetoCaprino.Domain.Repositories;
using TCC.ProjetoCaprino.Data.Repositories;
using TCC.ProjetoCaprino.Data;
using TCC.ProjetoCaprino.Shared;

namespace TCC.ProjetoCaprino.Ioc
{
    [ExcludeFromCodeCoverage]
    public static class IoCServiceExtension
    {
        public static void ConfigureAppDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureDbContext(services, configuration);

            services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            ConfigurarFluentValidation(services);

            ConfigureMinio(services, configuration);

            services.AddScoped<IMinioService, MinioService>();

            services.AddScoped<ICaprinoRepository, CaprinoRepository>();
            services.AddScoped<ITipoDeCriacaoRepository, TipoDeCriacaoRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IVacinaRepository, VacinaRepository>();
            services.AddScoped<ITipoDeAlimentoRepository, TipoDeAlimentoRepository>();
            services.AddScoped<IRacaRepository, RacaRepositiory>();

            services.AddHealthChecks().AddDbContextCheck<ApplicationDbContext>();

        }

        private static void ConfigurarFluentValidation(IServiceCollection services)
        {
            var abstractValidator = typeof(AbstractValidator<>);
            var validadores = typeof(IValida)
                .Assembly
                .DefinedTypes
                .Where(type => type.BaseType?.IsGenericType is true &&
                type.BaseType.GetGenericTypeDefinition() ==
                abstractValidator)
                .Select(Activator.CreateInstance)
                .ToArray();

            foreach (var validator in validadores)
            {
                services.AddSingleton(validator!.GetType().BaseType!, validator);
            }
        }

        private static void ConfigureDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<ApplicationDbContextInitialiser>();
        }

        private static void ConfigureMinio(IServiceCollection services, IConfiguration configuration)
        {
            var endpoint = configuration["MinIO:Endpoint"];
            var accesskey = configuration["MinIO:AccessKey"];
            var secretkey = configuration["MinIO:SecretKey"];

            services.AddScoped(sp =>
            {
                return new MinioClient()
                    .WithEndpoint(endpoint)
                    .WithCredentials(accesskey, secretkey)
                    .Build();
            });
        }

    }
}

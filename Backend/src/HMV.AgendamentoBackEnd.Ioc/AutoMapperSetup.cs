using HMV.AgendamentoBackEnd.Service.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HMV.AgendamentoBackEnd.Infra.Ioc
{
    /// <summary>
    /// DI do Automapper
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Configura o Automapper
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutoMapper(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.AddProfile(new DomainToViewModelMappingProfile());
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}

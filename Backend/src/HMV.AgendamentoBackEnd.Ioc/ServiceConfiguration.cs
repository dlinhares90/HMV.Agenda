using HMV.AgendamentoBackEnd.Service.Interfaces;
using HMV.AgendamentoBackEnd.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HMV.AgendamentoBackEnd.Infra.Ioc
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(ILovService), typeof(LovService));
            services.AddScoped(typeof(IAgendaService), typeof(AgendaService));
        }
    }
}

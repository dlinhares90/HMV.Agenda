using Microsoft.Extensions.DependencyInjection;
using NeurocorBackEnd.Service.Interfaces;
using NeurocorBackEnd.Service.Services;

namespace NeurocorBackEnd.Infra.Ioc
{
    public static class ServiceConfiguration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IAutenticacaoService), typeof(AutenticacaoService));
            services.AddScoped(typeof(IExameService), typeof(ExameService));
            services.AddScoped(typeof(IPacienteService), typeof(PacienteService));
            services.AddScoped(typeof(IUsuarioService), typeof(UsuarioService));
        }
    }
}

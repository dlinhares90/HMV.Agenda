using HMV.AgendamentoBackEnd.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HMV.AgendamentoBackEnd.Infra.Ioc
{
    public static class DataBaseConfiguration
    {
        public static void RegisterDataBase(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DataContext>(options => options
                .EnableSensitiveDataLogging(true)
                .UseOracle(Configuration.GetConnectionString("OracleDBConnection")
                ));
        }
    }
}

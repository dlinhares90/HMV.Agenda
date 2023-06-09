using HMV.AgendamentoBackEnd.Infra.Data;
using HMV.AgendamentoBackEnd.Infra.Ioc;
using HMV.AgendamentoBackEnd.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HMV.AgendamentoBackEnd
{
    /// <summary>
    /// Startup class
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// The configuration used during startup
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container. 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddMvc();
            services.AddCors();

            services.AddHttpClient("HttpClient");
            services.AddAutoMapper();
            services.AddSwaggerServices();
            services.RegisterDataBase(Configuration);
            services.RegisterServices();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            app.UseCors(option => option
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.AddSwaggerConfiguration(env);

            // Apply Migrations
            //dataContext.Database.Migrate();
        }
    }
}

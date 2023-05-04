using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace HMV.AgendamentoBackEnd
{
    /// <summary>
    /// Program Class
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Application Main()
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Application Host Creation
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

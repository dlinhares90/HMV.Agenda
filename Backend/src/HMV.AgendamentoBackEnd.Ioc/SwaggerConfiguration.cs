using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace NeurocorBackEnd.Ioc
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerServices(this IServiceCollection services)
        {
            var app = PlatformServices.Default.Application;

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = app.ApplicationName,
                    Version = app.ApplicationVersion
                });

                foreach (var xmlFile in GetXmlCommentsFiles())
                {
                    c.IncludeXmlComments(xmlFile);
                }
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application builder</param>
        /// <param name="env">The hosting environment</param>
        public static void AddSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            if (env.IsDevelopment())
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
                    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
                    c.DefaultModelsExpandDepth(0);
                    c.DisplayRequestDuration();
                    c.RoutePrefix = string.Empty;
                });
            }
            else
            {
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "V1");
                    c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List);
                    c.DefaultModelsExpandDepth(0);
                    c.DisplayRequestDuration();
                    c.RoutePrefix = string.Empty;
                });
            }
        }


        /// <summary>
        /// Gets the path to the Xml Comments file for the Web API assembly
        /// </summary>
        /// <returns></returns>
        private static List<string> GetXmlCommentsFiles()
        {
            List<string> files = new List<string>();
            try
            {
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var binFilePath = baseDirectory;
                foreach (var file in Directory.EnumerateFiles(binFilePath, "*.xml"))
                {
                    files.Add(file);
                }

                return files;
            }
            catch
            {
                return files;
            }
        }
    }
}

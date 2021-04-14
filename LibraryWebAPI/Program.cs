using Unity.Microsoft.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using LibraryWebAPI.Services;
using Unity;
using System;

namespace LibraryWebAPI
{
    class Program
    {
        private readonly IDbService _dbService;

        public Program(IDbService dbService)
        {
            _dbService = dbService;
        }

        static void Main(string[] args)
        {
            var container = new UnityDiContainerProvider().GetContainer();
            container.Resolve<Program>().Run(container);
        }

        private void Run(IUnityContainer container)
        {
            _dbService.EnsureDatabaseMigration();

            WebHost
                .CreateDefaultBuilder()
                .UseUnityServiceProvider(container)
                .ConfigureServices(services =>
                {
                    services.AddMvc();
                    services.AddSwaggerGen(SwaggerDocsConfig);
                })
                .Configure(app =>
                {
                    app.UseRouting();
                    app.UseCors(builder => builder.WithOrigins("http://localhost:4200")
                                .AllowAnyMethod()
                                .AllowAnyHeader());
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllers();
                    });
                    app.UseSwagger();
                    app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HW9");
                        c.RoutePrefix = string.Empty;
                    });
                })
                .UseUrls("http://*:10500")
                .Build()
                .Run();
        }

        private static void SwaggerDocsConfig(SwaggerGenOptions genOptions)
        {
            genOptions.SwaggerDoc(
                "v1",
                new OpenApiInfo
                {
                    Version = "v1",
                    Title = "HW9",
                    Description = "HomeWork 9",
                });
        }
    }
}

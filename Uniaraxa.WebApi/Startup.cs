using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Uniaraxa.Infrastructure;

namespace Uniaraxa.WebApi
{
    /// <summary>
    /// Classe responsável por configurar a inicialização da aplicação.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Construtor da classe Startup.
        /// </summary>
        /// <param name="configuration">A configuração da aplicação.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Obtém ou define a configuração da aplicação.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configura os serviços do aplicativo.
        /// </summary>
        /// <param name="services">A coleção de serviços.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddInfrastructure();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Uniaraxa - WebApi",
                });
            });
        }

        /// <summary>
        /// Configura o pipeline de requisição HTTP.
        /// </summary>
        /// <param name="app">O objeto IApplicationBuilder.</param>
        /// <param name="env">O ambiente de hospedagem web.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Uniaraxa");
            });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

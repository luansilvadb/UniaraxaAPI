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
    /// Classe respons�vel por configurar a inicializa��o da aplica��o.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Construtor da classe Startup.
        /// </summary>
        /// <param name="configuration">A configura��o da aplica��o.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Obt�m ou define a configura��o da aplica��o.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configura os servi�os do aplicativo.
        /// </summary>
        /// <param name="services">A cole��o de servi�os.</param>
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

            // Configurar a pol�tica de CORS
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
            });
            });
        }


        /// <summary>
        /// Configura o pipeline de requisi��o HTTP.
        /// </summary>
        /// <param name="app">O objeto IApplicationBuilder.</param>
        /// <param name="env">O ambiente de hospedagem web.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("AllowAllOrigins");

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Uniaraxa");

            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
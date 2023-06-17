using Microsoft.Extensions.DependencyInjection;
using Uniaraxa.Application.Interfaces;
using Uniaraxa.Infrastructure.Repository;

namespace Uniaraxa.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IFuncionarioRepository, FuncionarioRepository>();
            services.AddTransient<IAvaliacaoRepository, AvaliacaoRepository>();
            services.AddTransient<IAvaliadorRepository, AvaliadorRepository>();
            services.AddTransient<ICampanhaRepository, CampanhaRepository>();
            services.AddTransient<ISugestaoRepository, SugestaoRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}

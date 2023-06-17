using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Uniaraxa.Application.Interfaces;
using Uniaraxa.Core.Entities;

namespace Uniaraxa.Infrastructure.Repository
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly IConfiguration configuration;
        public AvaliacaoRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Avaliacao entity)
        {
            var sql = "Insert into Avaliacao (Criatividade, Investimento, Tempo_Implantacao, Reducao_custo, Vencedora, Sugestao_Id) VALUES (@Criatividade, @Investimento, @Tempo_Implantacao, @Reducao_custo, @Vencedora, @Sugestao_Id)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Avaliacao WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Avaliacao>> GetAllAsync()
        {
            var sql = "SELECT * FROM Avaliacao";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Avaliacao>(sql);
                return result.ToList();
            }
        }

        public async Task<Avaliacao> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Avaliacao WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Avaliacao>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Avaliacao entity)
        {
            var sql = "UPDATE Avaliacao SET Criatividade = @Criatividade, Investimento = @Investimento, Tempo_implantacao = @Tempo_implantacao, Reducao_custo = @Reducao_custo, Vencedora = @Vencedora,Sugestao_Id = @Sugestao_Id WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}

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
    public class SugestaoRepository : ISugestaoRepository
    {
        private readonly IConfiguration configuration;
        public SugestaoRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Sugestao entity)
        {
            var sql = "Insert into Sugestao (Descricao,Custos_envolvidos,Campanha_Id) VALUES (@Descricao,@Custos_Envolvidos,@Campanha_Id)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Sugestao WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Sugestao>> GetAllAsync()
        {
            var sql = "SELECT * FROM Sugestao";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Sugestao>(sql);
                return result.ToList();
            }
        }

        public async Task<Sugestao> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Sugestao WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Sugestao>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Sugestao entity)
        {
            var sql = "UPDATE Sugestao SET Descricao = @Descricao, Custo_envolvidos = @Custo_envolvidos, Campanha_Id = @Campanha_Id WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}

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
    public class AvaliadorRepository : IAvaliadorRepository
    {
        private readonly IConfiguration configuration;
        public AvaliadorRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Avaliador entity)
        {
            var sql = "Insert into Avaliador (Nome,Cpf) VALUES (@Nome,@Cpf)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Avaliador WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Avaliador>> GetAllAsync()
        {
            var sql = "SELECT * FROM Avaliador";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Avaliador>(sql);
                return result.ToList();
            }
        }

        public async Task<Avaliador> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Avaliador WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Avaliador>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Avaliador entity)
        {
            var sql = "UPDATE Avaliador SET Nome = @Nome, Cpf = @Cpf  WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}

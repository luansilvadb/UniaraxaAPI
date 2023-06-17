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
    public class CampanhaRepository : ICampanhaRepository
    {
        private readonly IConfiguration configuration;
        public CampanhaRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Campanha entity)
        {
            var sql = "Insert into Campanha (Responsavel,Nome,Descricao,Periodo,Valor_Premio,Avaliador_Id) VALUES (@Responsavel,@Nome,@Descricao,@Periodo,@Valor_Premio,@Avaliador_Id)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Campanha WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Campanha>> GetAllAsync()
        {
            var sql = "SELECT * FROM Campanha";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Campanha>(sql);
                return result.ToList();
            }
        }

        public async Task<Campanha> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Campanha WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Campanha>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Campanha entity)
        {
            var sql = "UPDATE Campanha SET Responsavel = @Responsavel, Nome = @Nome, Descricao = @Descricao, Periodo = @Periodo, Valor_Premio = @Valor_Premio, Avaliador_Id = @Avaliador_Id WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
    }
}

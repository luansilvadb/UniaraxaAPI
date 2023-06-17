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
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly IConfiguration configuration;
        public FuncionarioRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<int> AddAsync(Funcionario entity)
        {
            var sql = "Insert into Funcionario (Login,Senha,Nome,Cpf) VALUES (@Login,@Senha,@Nome,@Cpf)";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }

        public async Task<int> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Funcionario WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, new { Id = id });
                return result;
            }
        }

        public async Task<IReadOnlyList<Funcionario>> GetAllAsync()
        {
            var sql = "SELECT * FROM Funcionario";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QueryAsync<Funcionario>(sql);
                return result.ToList();
            }
        }

        public async Task<Funcionario> GetByIdAsync(int id)
        {
            var sql = "SELECT * FROM Funcionario WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Funcionario>(sql, new { Id = id });
                return result;
            }
        }

        public async Task<int> UpdateAsync(Funcionario entity)
        {
            var sql = "UPDATE Funcionario SET Login = @Login, Senha = @Senha, Nome = @Nome, Cpf = @Cpf  WHERE Id = @Id";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.ExecuteAsync(sql, entity);
                return result;
            }
        }
        public async Task<Funcionario> ValidateCredentialsAsync(string cpf, string senha)
        {
            var sql = "SELECT * FROM Funcionario WHERE Cpf = @Cpf AND Senha = @Senha";
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                var result = await connection.QuerySingleOrDefaultAsync<Funcionario>(sql, new { Cpf = cpf, Senha = senha });
                return result;
            }
        }
    }
}

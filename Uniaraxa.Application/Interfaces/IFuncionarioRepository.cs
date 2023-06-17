using System.Threading.Tasks;
using Uniaraxa.Core.Entities;

namespace Uniaraxa.Application.Interfaces
{
    public interface IFuncionarioRepository : IGenericRepository<Funcionario>
    {
        Task<Funcionario> ValidateCredentialsAsync(string cpf, string senha);
    }
}

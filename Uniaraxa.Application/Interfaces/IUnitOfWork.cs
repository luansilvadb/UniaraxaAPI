
namespace Uniaraxa.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IFuncionarioRepository Funcionario { get; }
        IAvaliacaoRepository Avaliacao { get; }
        IAvaliadorRepository Avaliador { get; }
        ICampanhaRepository Campanha { get; }
        ISugestaoRepository Sugestao { get; }
    }
}

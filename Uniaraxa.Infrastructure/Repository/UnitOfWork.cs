using Uniaraxa.Application.Interfaces;

namespace Uniaraxa.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        public UnitOfWork(IFuncionarioRepository funcionarioRepository,
                          IAvaliadorRepository avaliadorRepository,
                          IAvaliacaoRepository avaliacaoRepository,
                          ICampanhaRepository campanhaRepository,
                          ISugestaoRepository sugestaoRepository)
        {
            Funcionario = funcionarioRepository;
            Avaliador = avaliadorRepository;
            Avaliacao = avaliacaoRepository;
            Campanha = campanhaRepository;
            Sugestao = sugestaoRepository;

        }
        public IFuncionarioRepository Funcionario { get; }
        public IAvaliadorRepository Avaliador{ get; }
        public IAvaliacaoRepository Avaliacao { get; }
        public ICampanhaRepository Campanha { get; }
        public ISugestaoRepository Sugestao { get; }
    }
}

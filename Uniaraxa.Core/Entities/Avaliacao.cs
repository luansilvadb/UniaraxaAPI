namespace Uniaraxa.Core.Entities
{
    public class Avaliacao
    {
        public long Id { get; set; }
        public int Criatividade { get; set; }
        public int Investimento { get; set; }
        public int Tempo_Implantacao { get; set; }
        public int Reducao_Custo { get; set; }
        public bool Vencedora { get; set; }
        public long Sugestao_Id { get; set; }
        public Sugestao Sugestao { get; set; }
    }
}
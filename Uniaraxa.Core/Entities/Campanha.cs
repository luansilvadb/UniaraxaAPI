namespace Uniaraxa.Core.Entities
{
    public class Campanha
    {
        public long Id { get; set; }
        public string Responsavel { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Periodo { get; set; }
        public double Valor_Premio { get; set; }
        public long Avaliador_Id { get; set; }
        public Avaliador Avaliador { get; set; }
    }
}
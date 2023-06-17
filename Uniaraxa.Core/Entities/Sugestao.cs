using System.Collections.Generic;

namespace Uniaraxa.Core.Entities
{
    public class Sugestao
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public decimal Custos_Envolvidos { get; set; }
        public long Campanha_Id { get; set; }
        public Campanha Campanha { get; set; }
        public List<Avaliacao> Avaliacoes { get; set; }

        public Sugestao()
        {
            Avaliacoes = new List<Avaliacao>();
        }
    }
}
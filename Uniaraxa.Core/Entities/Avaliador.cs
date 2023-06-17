using System.Collections.Generic;

namespace Uniaraxa.Core.Entities
{
    public class Avaliador
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public List<Campanha> Campanhas { get; set; }

        public Avaliador()
        {
            Campanhas = new List<Campanha>();
        }
    }
}
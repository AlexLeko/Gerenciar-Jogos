using System;
using System.Collections.Generic;

namespace GerenciarJogos.Domain.Entities
{
    public class TipoConsole
    {
        public int ConsoleId { get; set; }

        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }


        #region [Vinculos]

        public int JogoId { get; set; }

        public virtual IEnumerable<Jogo> Jogos { get; set; }

        #endregion
    }
}

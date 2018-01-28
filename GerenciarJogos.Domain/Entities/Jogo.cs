using System;

namespace GerenciarJogos.Domain.Entities
{
    public class Jogo
    {
        public int JogoId { get; set; }

        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public bool IsEmprestado { get; set; }


        #region [Vinculos]
        public int ConsoleId { get; set; }

        public virtual TipoConsole Console { get; set; }

        #endregion


    }
}

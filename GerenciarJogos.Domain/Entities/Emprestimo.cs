using System;

namespace GerenciarJogos.Domain.Entities
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataDevolucao { get; set; }

        public bool IsAtivo { get; set; }

        public bool IsEmprestado { get; set; }

        public string Observacao { get; set; }


        #region [Vinculos]

        public int AmigoId { get; set; }

        public virtual Amigo Amigo { get; set; }

        public int JogoId { get; set; }

        public virtual Jogo Jogo { get; set; }

        #endregion

    }
}

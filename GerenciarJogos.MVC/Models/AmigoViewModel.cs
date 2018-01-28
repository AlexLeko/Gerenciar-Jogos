using GerenciarJogos.Common.Enumeradores;
using System;

namespace GerenciarJogos.MVC.Models
{
    public class AmigoViewModel
    {
        public int AmigoId { get; set; }

        public string Nome { get; set; }

        public string Apelido { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }


        #region [FORMATADOS]

        public string StatusFormatado
        {
            get
            {
                return Ativo ? StatusConsoleEnum.ATIVO.ToString() : StatusConsoleEnum.DESATIVADO.ToString();
            }

        }

        #endregion

    }
}
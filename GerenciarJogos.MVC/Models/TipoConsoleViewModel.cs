using GerenciarJogos.Common.Enumeradores;
using System;
using System.Collections.Generic;

namespace GerenciarJogos.MVC.Models
{
    public class TipoConsoleViewModel
    {        
        public int ConsoleId { get; set; }

        public string Nome { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public int JogoId { get; set; }

        public IEnumerable<JogoViewModel> Jogos { get; set; }

        #region [FORMATADOS]
        public StatusConsoleEnum ListaStatus { get; set; }

        public string Status
        {
            get
            {
                return Ativo ? StatusConsoleEnum.ATIVO.ToString() : StatusConsoleEnum.DESATIVADO.ToString();
            }
            set { }
        }

        #endregion
    }
}
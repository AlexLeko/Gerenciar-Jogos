using GerenciarJogos.Common.Enumeradores;
using GerenciarJogos.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarJogos.MVC.Models
{
    public class JogoViewModel
    {
        public int JogoId { get; set; }

        public string Nome { get; set; }

        public System.DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public bool IsEmprestado { get; set; }


        #region [TIPO CONSOLE]
        public TipoConsoleViewModel Console { get; set; }

        public IEnumerable<TipoConsole> Consoles { get; set; }

        public int ConsoleSelecionado { get; set; }

        #endregion


        #region [FORMATADOS]

        public string EmprestadoFormatado
        {
            get
            {
                return IsEmprestado ? OpcaoSimNaoEnum.SIM.ToString() : OpcaoSimNaoEnum.NAO.ToString();
            }
            set { }
        }

        public string StatusFormatado
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
using GerenciarJogos.Common.Enumeradores;
using System;
using System.Collections.Generic;

namespace GerenciarJogos.MVC.Models
{
    public class EmprestimoViewModel
    {
        public int EmprestimoId { get; set; }

        public DateTime DataCadastro { get; set; }

        public DateTime? DataDevolucao { get; set; }

        public bool IsAtivo { get; set; }

        public bool IsEmprestado { get; set; }

        public string Observacao { get; set; }


        #region [Vinculos]
        public int AmigoId { get; set; }

        public virtual AmigoViewModel Amigo { get; set; }

        public IEnumerable<AmigoViewModel> Amigos { get; set; }


        public int JogoId { get; set; }

        public virtual JogoViewModel Jogo { get; set; }

        public IEnumerable<JogoViewModel> Jogos { get; set; }


        #endregion

        public string EmprestadoFormatado
        {
            get
            {
                if (IsAtivo)
                    return IsEmprestado ? StatusEmprestimoEnum.EMPRESTADO.ToString() : StatusEmprestimoEnum.LIVRE.ToString();

                return StatusEmprestimoEnum.DEVOLVIDO.ToString();
            }
            set { }
        }

        public string DataCadastroFormatado
        {
            get
            {
                if (DataCadastro != default(DateTime))
                {
                    return DataCadastro.ToShortDateString();
                }
                return string.Empty;
            }
            set { }
        }

        public string DataDevolucaoFormatado
        {
            get
            {
                if (DataDevolucao != default(DateTime) && DataDevolucao != null)
                {
                    return DataDevolucao.Value.ToShortDateString();
                }
                return string.Empty;
            }
            set { }
        }
    }
}
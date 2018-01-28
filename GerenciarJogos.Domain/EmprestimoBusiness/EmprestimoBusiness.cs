using GerenciarJogos.Common.Mensagens;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Domain;
using GerenciarJogos.Domain.Interface.Services;
using System;

namespace GerenciarJogos.Domain.EmprestimoBusiness
{
    public class EmprestimoBusiness : IEmprestimoBusiness
    {
        #region [CONSTANTES]
        public IEmprestimoService _emprestimoService;
        private readonly IJogoService _jogoService;

        #endregion

        #region [CONSTRUTOR]
        public EmprestimoBusiness(IEmprestimoService emprestimoService, IJogoService jogoService)
        {
            _emprestimoService = emprestimoService;
            _jogoService = jogoService;
        }
        #endregion

        #region [ACOES]

        public void FinalizarEmprestimo(int codigo)
        {
            try
            {
                if (codigo > 0)
                {
                    var emprestimo = _emprestimoService.RecuperarPorId(codigo);
                    if (emprestimo != null)
                    {
                        FinalizarSituacaoEmprestimo(emprestimo);
                        AtualizarSituacaoEmprestimoJogo(emprestimo.JogoId, false);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Concat(Mensagem.ERRO_ACESSO_DADOS, ex));
            }
        }

        #endregion

        #region [AUXILIARES]
        private void FinalizarSituacaoEmprestimo(Emprestimo emprestimo)
        {
            emprestimo.DataDevolucao = DateTime.Now;
            emprestimo.IsAtivo = false;
            emprestimo.IsEmprestado = false;
            _emprestimoService.Atualizar(emprestimo);
        }

        private void AtualizarSituacaoEmprestimoJogo(int jogoId, bool situacao)
        {
            var jogo = _jogoService.RecuperarPorId(jogoId);
            jogo.IsEmprestado = situacao;
            _jogoService.Atualizar(jogo);
        }

        #endregion
    }
}

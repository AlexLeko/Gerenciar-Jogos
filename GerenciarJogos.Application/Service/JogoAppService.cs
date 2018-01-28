using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Services;
using System.Collections.Generic;

namespace GerenciarJogos.Application.Service
{
    public class JogoAppService : AppServiceBase<Jogo>, IJogoAppService
    {
        #region [CONSTANTES]
        private readonly IJogoService _jogoService;

        #endregion

        #region [CONSTRUTOR]
        public JogoAppService(IJogoService jogoService) : base(jogoService)
        {
            _jogoService = jogoService;
        }
        #endregion

        #region [METODOS]
        public IEnumerable<Jogo> BuscarPorNome(string nome)
        {
            return _jogoService.BuscarPorNome(nome);
        }


        #endregion

    }
}

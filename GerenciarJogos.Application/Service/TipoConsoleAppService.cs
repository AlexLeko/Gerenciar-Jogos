using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Services;

namespace GerenciarJogos.Application.Service
{
    public class TipoConsoleAppService : AppServiceBase<TipoConsole>, ITipoConsoleAppService
    {
        #region [CONSTANTES]
        private readonly ITipoConsoleService _consoleService;

        #endregion

        #region [CONSTRUTOR]
        public TipoConsoleAppService(ITipoConsoleService consoleService) : base(consoleService)
        {
            _consoleService = consoleService;
        }



        #endregion

    }
}

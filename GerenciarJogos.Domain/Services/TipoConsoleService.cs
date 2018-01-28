using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Repositories;
using GerenciarJogos.Domain.Interface.Services;

namespace GerenciarJogos.Domain.Services
{
    public class TipoConsoleService : ServiceBase<TipoConsole>, ITipoConsoleService
    {
        #region [CONSTANTES]
        private readonly ITipoConsoleRepository _consoleRepository;

        #endregion

        #region [CONSTRUTOR]
        public TipoConsoleService(ITipoConsoleRepository consoleRepository) : base(consoleRepository)
        {
            _consoleRepository = consoleRepository;
        }
        #endregion

    }
}

using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Services;

namespace GerenciarJogos.Application.Service
{
    public class UsuarioAppService : AppServiceBase<Usuario>, IUsuarioAppService
    {
        #region [CONSTANTES]
        private readonly IUsuarioService _usuarioService;

        #endregion

        #region [CONSTRUTOR]
        public UsuarioAppService(IUsuarioService usuarioService) : base(usuarioService)
        {
            _usuarioService = usuarioService;
        }
        #endregion

        #region [METODOS]
        public Usuario RecuperarUsuarioLogin(string nome, string senha)
        {
            return _usuarioService.RecuperarUsuarioLogin(nome, senha);

        }

        #endregion

    }
}

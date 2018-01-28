using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Repositories;
using GerenciarJogos.Domain.Interface.Services;

namespace GerenciarJogos.Domain.Services
{
    public class UsuarioService : ServiceBase<Usuario>, IUsuarioService
    {
        #region [CONSTANTES]
        private readonly IUsuarioRepository _usuarioRepository;
        #endregion

        #region [CONSTRUTOR]
        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        #endregion

        #region [METODOS]
        public Usuario RecuperarUsuarioLogin(string nome, string senha)
        {
            return _usuarioRepository.RecuperarUsuarioLogin(nome, senha);
        }
        
        #endregion

    }
}

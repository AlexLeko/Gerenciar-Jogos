using GerenciarJogos.Domain.Entities;

namespace GerenciarJogos.Domain.Interface.Services
{
    public interface IUsuarioService : IServiceBase<Usuario>
    {
        Usuario RecuperarUsuarioLogin(string nome, string senha);

    }
}

using GerenciarJogos.Domain.Entities;

namespace GerenciarJogos.Application.Interface
{
    public interface IUsuarioAppService : IAppServiceBase<Usuario>
    {
        Usuario RecuperarUsuarioLogin(string nome, string senha);
    }
}

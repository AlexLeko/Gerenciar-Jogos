using GerenciarJogos.Domain.Entities;

namespace GerenciarJogos.Domain.Interface.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario RecuperarUsuarioLogin(string nome, string senha);

    }
}

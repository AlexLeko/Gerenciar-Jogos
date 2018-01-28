using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Repositories;
using System.Linq;

namespace GerenciarJogos.Infra.Data.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public Usuario RecuperarUsuarioLogin(string nome, string senha)
        {
            return Db.Usuarios.Where(u => u.Nome == nome && u.Senha == senha).FirstOrDefault();
        }
    }
}

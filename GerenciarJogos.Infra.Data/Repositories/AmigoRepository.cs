using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GerenciarJogos.Infra.Data.Repositories
{
    public class AmigoRepository : RepositoryBase<Amigo>, IAmigoRepository
    {
        public IEnumerable<Amigo> BuscarAmigoPorNome(string nome)
        {
            return Db.Amigos.Where(J => J.Nome == nome);
        }
    }
}

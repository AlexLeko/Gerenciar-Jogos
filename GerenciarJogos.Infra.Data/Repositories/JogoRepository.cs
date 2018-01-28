using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GerenciarJogos.Infra.Data.Repositories
{
    public class JogoRepository : RepositoryBase<Jogo>, IJogoRepository
    {
        public IEnumerable<Jogo> BuscarPorNome(string nome)
        {
            return Db.Jogos.Where(J => J.Nome == nome);
        }
    }
}

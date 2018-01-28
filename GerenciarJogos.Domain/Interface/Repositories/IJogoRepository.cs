using GerenciarJogos.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarJogos.Domain.Interface.Repositories
{
    public interface IJogoRepository : IRepositoryBase<Jogo>
    {
        IEnumerable<Jogo> BuscarPorNome(string nome);

    }
}

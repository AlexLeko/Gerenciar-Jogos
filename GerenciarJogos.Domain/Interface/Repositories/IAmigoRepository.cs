using GerenciarJogos.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarJogos.Domain.Interface.Repositories
{
    public interface IAmigoRepository : IRepositoryBase<Amigo>
    {
        IEnumerable<Amigo> BuscarAmigoPorNome(string nome);

    }
}

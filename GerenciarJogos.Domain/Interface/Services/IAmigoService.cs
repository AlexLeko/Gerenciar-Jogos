using GerenciarJogos.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarJogos.Domain.Interface.Services
{
    public interface IAmigoService : IServiceBase<Amigo>
    {
        IEnumerable<Amigo> BuscarAmigoPorNome(string nome);

    }
}

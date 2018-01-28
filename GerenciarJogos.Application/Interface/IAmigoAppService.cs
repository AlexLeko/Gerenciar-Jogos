using GerenciarJogos.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarJogos.Application.Interface
{
    public interface IAmigoAppService : IAppServiceBase<Amigo>
    {
        IEnumerable<Amigo> BuscarAmigoPorNome(string nome);
    }
}

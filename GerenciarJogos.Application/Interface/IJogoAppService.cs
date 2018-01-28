using GerenciarJogos.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarJogos.Application.Interface
{
    public interface IJogoAppService : IAppServiceBase<Jogo>
    {
        IEnumerable<Jogo> BuscarPorNome(string nome);
    }
}

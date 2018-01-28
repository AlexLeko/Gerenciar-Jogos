using GerenciarJogos.Domain.Entities;
using System.Collections.Generic;

namespace GerenciarJogos.Domain.Interface.Services
{
    public interface IJogoService : IServiceBase<Jogo>
    {
        IEnumerable<Jogo> BuscarPorNome(string nome);

    }
}

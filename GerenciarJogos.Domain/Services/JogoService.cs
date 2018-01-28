using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Repositories;
using GerenciarJogos.Domain.Interface.Services;
using System.Collections.Generic;

namespace GerenciarJogos.Domain.Services
{
    public class JogoService : ServiceBase<Jogo>, IJogoService
    {
        #region [CONSTANTES]
        private readonly IJogoRepository _jogoRepository;
        #endregion

        #region [CONSTRUTOR]
        public JogoService(IJogoRepository jogoRepository) : base(jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }
        #endregion

        #region [METODOS]
        public IEnumerable<Jogo> BuscarPorNome(string nome)
        {
            return _jogoRepository.BuscarPorNome(nome);
        }

        #endregion

    }
}

using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Repositories;
using GerenciarJogos.Domain.Interface.Services;
using System.Collections.Generic;

namespace GerenciarJogos.Domain.Services
{
    public class AmigoService : ServiceBase<Amigo>, IAmigoService
    {
        #region [CONSTANTES]
        private readonly IAmigoRepository _amigoRepository;
        #endregion

        #region [CONSTRUTOR]
        public AmigoService(IAmigoRepository amigoRepository) : base(amigoRepository)
        {
            _amigoRepository = amigoRepository;
        }

        #endregion

        #region [METODOS]

        public IEnumerable<Amigo> BuscarAmigoPorNome(string nome)
        {
            return _amigoRepository.BuscarAmigoPorNome(nome);
        }

        #endregion


    }
}

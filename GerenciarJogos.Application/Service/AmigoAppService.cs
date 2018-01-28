using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Services;
using System.Collections.Generic;

namespace GerenciarJogos.Application.Service
{
    public class AmigoAppService : AppServiceBase<Amigo>, IAmigoAppService
    {
        #region [CONSTANTES]
        private readonly IAmigoService _amigoService;

        #endregion

        #region [CONSTRUTOR]
        public AmigoAppService(IAmigoService amigoService) : base(amigoService)
        {
            _amigoService = amigoService;
        }
        #endregion

        #region [METODOS]
        public IEnumerable<Amigo> BuscarAmigoPorNome(string nome)
        {
            return _amigoService.BuscarAmigoPorNome(nome);
        }


        #endregion

    }
}

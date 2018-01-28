using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Services;

namespace GerenciarJogos.Application.Service
{
    public class EmprestimoAppService : AppServiceBase<Emprestimo>, IEmprestimoAppService
    {
        #region [CONSTANTES]
        private readonly IEmprestimoService _emprestimoService;

        #endregion

        #region [CONSTRUTOR]
        public EmprestimoAppService(IEmprestimoService emprestimoService) : base(emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }


        #endregion

    }
}

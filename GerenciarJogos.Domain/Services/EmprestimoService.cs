using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Repositories;
using GerenciarJogos.Domain.Interface.Services;

namespace GerenciarJogos.Domain.Services
{
    public class EmprestimoService : ServiceBase<Emprestimo>, IEmprestimoService
    {
        #region [CONSTANTES]
        private readonly IEmprestimoRepository _emprestimoRepository;
        #endregion

        #region [CONSTRUTOR]
        public EmprestimoService(IEmprestimoRepository emprestimoRepository) : base(emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }
        #endregion

    }
}

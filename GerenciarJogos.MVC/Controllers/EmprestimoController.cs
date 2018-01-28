using AutoMapper;
using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.MVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GerenciarJogos.MVC.Controllers
{
    public class EmprestimoController : Controller
    {
        #region [CONSTANTES]

        public IEmprestimoAppService _emprestimoService;
        private readonly IJogoAppService _jogoService;
        private readonly IAmigoAppService _amigoService;
        #endregion

        #region [CONSTRUTOR]

        public EmprestimoController(IEmprestimoAppService emprestimoService, IJogoAppService jogoService, IAmigoAppService amigoService)
        {
            _emprestimoService = emprestimoService;
            _jogoService = jogoService;
            _amigoService = amigoService;
        }
        #endregion


        #region [ACOES]

        public ActionResult Index()
        {
            var model = new EmprestimoViewModel();
            model.Jogos = PopularComboJogos(model);
            model.Amigos = PopularComboAmigos(model);

            return View(model);
        }

        private IEnumerable<AmigoViewModel> PopularComboAmigos(EmprestimoViewModel model)
        {
            var amigos = _amigoService.BuscarTodos().Where(a => a.Ativo);
            return Mapper.Map<IEnumerable<Amigo>, IEnumerable<AmigoViewModel>>(amigos);
        }

        private IEnumerable<JogoViewModel> PopularComboJogos(EmprestimoViewModel model)
        {
            var jogos = _jogoService.BuscarTodos().Where(j => j.Ativo).Where(j => !j.IsEmprestado);
            return Mapper.Map<IEnumerable<Jogo>, IEnumerable<JogoViewModel>>(jogos);
        }


        public ActionResult Visualizar(int codigo)
        {
            EmprestimoViewModel modelVM = new EmprestimoViewModel();

            var model = _emprestimoService.RecuperarPorId(codigo);
            if (model != null)
                modelVM = Mapper.Map<Emprestimo, EmprestimoViewModel>(model);

            return View(modelVM);
        }

        #endregion

    }
}
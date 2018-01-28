using AutoMapper;
using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.MVC.Models;
using System.Web.Mvc;

namespace GerenciarJogos.Controllers
{
    public class TipoConsoleController : Controller
    {
        #region [CONSTANTES]
        public ITipoConsoleAppService _consoleService;
        #endregion

        #region [CONSTRUTOR]
        public TipoConsoleController(ITipoConsoleAppService consoleService)
        {
            _consoleService = consoleService;
        }
        #endregion

        #region [ACOES]
        public ActionResult Index()
        {
            TipoConsoleViewModel model = new TipoConsoleViewModel();
            return View(model);
        }

        public ActionResult Visualizar(int codigo)
        {
            TipoConsoleViewModel modelVM = new TipoConsoleViewModel();

            var model = _consoleService.RecuperarPorId(codigo);
            if (model != null)
                modelVM = Mapper.Map<TipoConsole, TipoConsoleViewModel>(model);

            return View(modelVM);
        }

        #endregion

    }
}
using AutoMapper;
using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.MVC.Models;
using System.Linq;
using System.Web.Mvc;

namespace GerenciarJogos.MVC.Controllers
{
    public class JogoController : Controller
    {
        #region [CONSTANTES]
        private readonly IJogoAppService _jogoService;
        private readonly ITipoConsoleAppService _consoleService;
        #endregion

        #region [CONSTRUTOR]
        public JogoController(IJogoAppService jogoService, ITipoConsoleAppService consoleService)
        {
            _jogoService = jogoService;
            _consoleService = consoleService;
        }
        #endregion

        #region [ACOES]
        public ActionResult Index()
        {
            JogoViewModel model = new JogoViewModel();
            model.Consoles = _consoleService.BuscarTodos().Where(c => c.Ativo);

            return View(model);
        }

        public ActionResult Visualizar(int codigo)
        {
            JogoViewModel modelVM = new JogoViewModel();

            var model = _jogoService.RecuperarPorId(codigo);
            if (model != null)
                modelVM = Mapper.Map<Jogo, JogoViewModel>(model);

            return View(modelVM);
        }



        #endregion

    }
}
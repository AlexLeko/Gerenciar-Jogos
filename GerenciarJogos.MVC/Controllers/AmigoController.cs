using AutoMapper;
using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.MVC.Models;
using System.Web.Mvc;

namespace GerenciarJogos.MVC.Controllers
{
    public class AmigoController : Controller
    {
        #region [CONSTANTES]
        public IAmigoAppService _amigoService;
        #endregion

        #region [CONSTRUTOR]
        public AmigoController(IAmigoAppService amigoService)
        {
            _amigoService = amigoService;
        }
        #endregion

        #region [ACOES]
        public ActionResult Index()
        {
            AmigoViewModel model = new AmigoViewModel();
            return View(model);
        }

        public ActionResult Visualizar(int codigo)
        {
            AmigoViewModel modelVM = new AmigoViewModel();

            var model = _amigoService.RecuperarPorId(codigo);
            if (model != null)
                modelVM = Mapper.Map<Amigo, AmigoViewModel>(model);

            return View(modelVM);
        }
        #endregion

    }
}
using AutoMapper;
using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.MVC.Models;
using System.Web.Mvc;

namespace GerenciarJogos.MVC.Controllers
{
    public class LoginController : Controller
    {
        #region [CONSTANTES]
        public IUsuarioAppService _usuarioService;
        #endregion

        #region [CONSTRUTOR]
        public LoginController(IUsuarioAppService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        #endregion

        [HttpGet]
        public ActionResult Login()
        {
            UsuarioViewModel model = new UsuarioViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UsuarioViewModel model, string returnUrl)
        {
            Usuario entidade = new Usuario();

            if (string.IsNullOrEmpty(model.Nome) && string.IsNullOrEmpty(model.Senha))
            {
                model.IsError = true;
                return View(model);
            }

            var retorno = _usuarioService.RecuperarUsuarioLogin(model.Nome, model.Senha);

            if (retorno != null)
            {
                TempData["UsuarioLogado"] = retorno.Nome;
                System.Web.Security.FormsAuthentication.SetAuthCookie(retorno.Nome, false);

                return string.IsNullOrEmpty(returnUrl) ? Redirect("/Home") : Redirect(returnUrl);
            }
            else
            {
                model.IsError = true;
                return View(model);
            }
        }

        public ActionResult LogOff()
        {
            System.Web.Security.FormsAuthentication.SignOut();

            return Redirect("Login/Login");
        }

        [HttpPost]
        [Route("AdicionarConta")]
        public ActionResult AdicionarConta(UsuarioViewModel model)
        {
            Usuario entidade = new Usuario();

            if (string.IsNullOrEmpty(model.Nome) && string.IsNullOrEmpty(model.Senha))
            {
                model.IsError = true;
                return View(model);
            }

            var usuario = Mapper.Map<UsuarioViewModel, Usuario>(model);
            _usuarioService.Adicionar(usuario);

            TempData["UsuarioLogado"] = model.Nome;
            System.Web.Security.FormsAuthentication.SetAuthCookie(model.Nome, false);

            return Redirect("/Home");
        }

    }
}
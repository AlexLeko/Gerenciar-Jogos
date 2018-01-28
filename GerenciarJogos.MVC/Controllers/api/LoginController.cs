using AutoMapper;
using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.MVC.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GerenciarJogos.MVC.Controllers.api
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
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

        [HttpPost]
        [Route("AdicionarConta")]
        public HttpResponseMessage AdicionarConta(UsuarioViewModel model)
        {
            try
            {
                var usuario = Mapper.Map<UsuarioViewModel, Usuario>(model);
                _usuarioService.Adicionar(usuario);

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);


                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

    }
}

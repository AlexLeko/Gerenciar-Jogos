using AutoMapper;
using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GerenciarJogos.MVC.Controllers.api
{
    [RoutePrefix("api/TipoConsole")]

    public class TipoConsoleController : ApiController
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

        [HttpPost]
        [Route("BuscarTodos")]
        public HttpResponseMessage BuscarTodos(TipoConsoleViewModel model)
        {
            try
            {
                var retornoModel = new List<TipoConsoleViewModel>();

                var consoles = _consoleService.BuscarTodos();
                if (consoles.Any())
                    retornoModel = (Mapper.Map<IEnumerable<TipoConsole>, IEnumerable<TipoConsoleViewModel>>(consoles)).ToList();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, retornoModel);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }

        }

        [HttpPost]
        [Route("ManterConsole")]
        public HttpResponseMessage ManterConsole(TipoConsoleViewModel model)
        {
            try
            {
                if (model != null)
                {
                    var console = Mapper.Map<TipoConsoleViewModel, TipoConsole>(model);

                    if (console.ConsoleId > 0)
                    {
                        var consoleBD = _consoleService.RecuperarPorId(console.ConsoleId);
                        consoleBD.Nome = model.Nome;

                        _consoleService.Atualizar(consoleBD);
                    }
                    else
                    {
                        console.Ativo = true;
                        _consoleService.Adicionar(console);
                    }
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [HttpGet]
        public HttpResponseMessage AlterarStatus(int codigo)
        {
            try
            {
                if (codigo > 0)
                {
                    var console = _consoleService.RecuperarPorId(codigo);
                    console.Ativo = console.Ativo ? false : true;
                    _consoleService.Atualizar(console);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }


        [HttpGet]
        [Route("RecuperarConsole")]
        public HttpResponseMessage RecuperarConsole(int codigo)
        {
            try
            {
                var retornoModel = new TipoConsoleViewModel();

                if (codigo > 0)
                {
                    var console = _consoleService.RecuperarPorId(codigo);
                    if (console != null)
                        retornoModel = Mapper.Map<TipoConsole, TipoConsoleViewModel>(console);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, retornoModel);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        [HttpGet]
        [Route("RemoverConsole")]
        public HttpResponseMessage RemoverConsole(int codigo)
        {
            try
            {
                var retornoModel = new TipoConsoleViewModel();

                if (codigo > 0)
                {
                    var console = _consoleService.RecuperarPorId(codigo);
                    if (console != null)
                        _consoleService.Remover(console);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, retornoModel);
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                return response;
            }
        }

        #endregion
    }
}

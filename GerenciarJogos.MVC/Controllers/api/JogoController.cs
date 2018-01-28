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
    [RoutePrefix("api/Jogo")]
    public class JogoController : ApiController
    {
        #region [CONSTANTES]
        public IJogoAppService _jogoService;
        public ITipoConsoleAppService _consoleService;
        #endregion

        #region [CONSTRUTOR]
        public JogoController(IJogoAppService jogoService, ITipoConsoleAppService consoleService)
        {
            _jogoService = jogoService;
            _consoleService = consoleService;
        }
        #endregion

        #region [ACOES]

        [HttpPost]
        [Route("Buscar")]
        public HttpResponseMessage Buscar(JogoViewModel model)
        {
            try
            {
                var retornoModel = new List<JogoViewModel>();

                var jogos = _jogoService.BuscarTodos();
                if (jogos.Any())
                    retornoModel = (Mapper.Map<IEnumerable<Jogo>, IEnumerable<JogoViewModel>>(jogos)).ToList();

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
        [Route("ManterJogo")]
        public HttpResponseMessage ManterJogo(JogoViewModel model)
        {
            try
            {
                if (model != null)
                {
                    var jogo = Mapper.Map<JogoViewModel, Jogo>(model);
                    jogo.ConsoleId = model.ConsoleSelecionado;

                    if (jogo.JogoId > 0)
                    {
                        var jogoBD = _jogoService.RecuperarPorId(jogo.JogoId);
                        jogoBD.Nome = model.Nome;
                        jogoBD.ConsoleId = model.ConsoleSelecionado;

                        _jogoService.Atualizar(jogoBD);
                    }
                    else
                    {
                        jogo.Ativo = true;
                        _jogoService.Adicionar(jogo);
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
                    var jogo = _jogoService.RecuperarPorId(codigo);
                    jogo.Ativo = jogo.Ativo ? false : true;
                    _jogoService.Atualizar(jogo);
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
        [Route("RecuperarJogoPorId")]
        public HttpResponseMessage RecuperarJogoPorId(int codigo)
        {
            try
            {
                var retornoModel = new JogoViewModel();

                if (codigo > 0)
                {
                    var jogo = _jogoService.RecuperarPorId(codigo);
                    if (jogo != null)
                    {
                        retornoModel = Mapper.Map<Jogo, JogoViewModel>(jogo);
                        retornoModel.ConsoleSelecionado = jogo.Console.ConsoleId;
                    }
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

        //[HttpGet]
        //[Route("RemoverJogo")]
        //public HttpResponseMessage RemoverJogo(int codigo)
        //{
        //    try
        //    {
        //        var retornoModel = new TipoConsoleViewModel();

        //        if (codigo > 0)
        //        {
        //            var console = _jogoService.RecuperarPorId(codigo);
        //            if (console != null)
        //            {
        //                // se haver emprestimos nao podera excluir.
        //                //_jogoService.Remover(console);
        //            }
        //        }

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, retornoModel);
        //        return response;
        //    }
        //    catch (Exception ex)
        //    {
        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
        //        return response;
        //    }
        //}

        #endregion
    }
}

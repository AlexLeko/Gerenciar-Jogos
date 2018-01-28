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
    [RoutePrefix("api/Amigo")]
    public class AmigoController : ApiController
    {
        #region [CONSTANTES]
        private readonly IAmigoAppService _amigoService;

        #endregion

        #region [CONSTRUTOR]
        public AmigoController(IAmigoAppService amigoService)
        {
            _amigoService = amigoService;
        }
        
        #endregion

        #region [ACOES]

        [HttpPost]
        [Route("BuscarTodosAmigos")]
        public HttpResponseMessage BuscarTodosAmigos(AmigoViewModel model)
        {
            try
            {
                var retornoModel = new List<AmigoViewModel>();

                var amigos = _amigoService.BuscarTodos();
                if (amigos.Any())
                    retornoModel = (Mapper.Map<IEnumerable<Amigo>, IEnumerable<AmigoViewModel>>(amigos)).ToList();

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
        [Route("ManterAmigo")]
        public HttpResponseMessage ManterAmigo(AmigoViewModel model)
        {
            try
            {
                if (model != null)
                {
                    var amigo = Mapper.Map<AmigoViewModel, Amigo>(model);

                    if (amigo.AmigoId > 0)
                    {
                        var amigoBD = _amigoService.RecuperarPorId(amigo.AmigoId);
                        amigoBD.Nome = model.Nome;
                        amigoBD.Apelido = model.Apelido;
                        amigoBD.Telefone = model.Telefone;
                        amigoBD.Email = model.Email;

                        _amigoService.Atualizar(amigoBD);
                    }
                    else
                    {
                        amigo.Ativo = true;
                        _amigoService.Adicionar(amigo);
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
        public HttpResponseMessage AlterarStatusAmigo(int codigo)
        {
            try
            {
                if (codigo > 0)
                {
                    var amigo = _amigoService.RecuperarPorId(codigo);
                    amigo.Ativo = amigo.Ativo ? false : true;
                    _amigoService.Atualizar(amigo);
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
        [Route("RecuperarAmigoPorId")]
        public HttpResponseMessage RecuperarAmigoPorId(int codigo)
        {
            try
            {
                var retornoModel = new AmigoViewModel();
                if (codigo > 0)
                {
                    var amigo = _amigoService.RecuperarPorId(codigo);
                    if (amigo != null)
                        retornoModel = Mapper.Map<Amigo, AmigoViewModel>(amigo);
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

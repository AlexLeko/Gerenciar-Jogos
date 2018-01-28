using AutoMapper;
using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Entities;
using GerenciarJogos.Domain.Interface.Domain;
using GerenciarJogos.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GerenciarJogos.MVC.Controllers.api
{
    [RoutePrefix("api/Emprestimo")]
    public class EmprestimoController : ApiController
    {
        #region [CONSTANTES]
        public readonly IEmprestimoAppService _emprestimoService;
        private readonly IEmprestimoBusiness _emprestimoBusiness;
        private readonly IJogoAppService _jogoService;
        private readonly IAmigoAppService _amigoService;

        #endregion

        #region [CONSTRUTOR]
        public EmprestimoController(IEmprestimoAppService emprestimoService,
            IJogoAppService jogoService, IAmigoAppService amigoService,
            IEmprestimoBusiness emprestimoBusiness)
        {
            _emprestimoService = emprestimoService;
            _jogoService = jogoService;
            _emprestimoBusiness = emprestimoBusiness;
        }
        #endregion

        [HttpPost]
        [Route("BuscarTodosEmprestimos")]
        public HttpResponseMessage BuscarTodosEmprestimos(EmprestimoViewModel model)
        {
            try
            {
                var retornoModel = new List<EmprestimoViewModel>();

                var emprestimos = _emprestimoService.BuscarTodos();
                if (emprestimos.Any())
                    retornoModel = (Mapper.Map<IEnumerable<Emprestimo>, IEnumerable<EmprestimoViewModel>>(emprestimos)).ToList();

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
        [Route("ManterEmprestimo")]
        public HttpResponseMessage ManterEmprestimo(EmprestimoViewModel model)
        {
            try
            {
                if (model != null)
                {
                    var emprestimo = Mapper.Map<EmprestimoViewModel, Emprestimo>(model);
                    emprestimo.JogoId = model.JogoId;
                    emprestimo.AmigoId = model.AmigoId;
                    emprestimo.Observacao = model.Observacao;

                    if (emprestimo.EmprestimoId > 0)
                    {
                        var emp = _emprestimoService.RecuperarPorId(emprestimo.EmprestimoId);
                        emp.Observacao = model.Observacao;

                        _emprestimoService.Atualizar(emp);
                    }
                    else
                        AdicionarNovoEmprestimo(emprestimo);

                    AtualizarSituacaoEmprestimoJogo(emprestimo.JogoId, true);
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

        private void AdicionarNovoEmprestimo(Emprestimo emprestimo)
        {
            emprestimo.IsAtivo = true;
            emprestimo.IsEmprestado = true;
            _emprestimoService.Adicionar(emprestimo);
        }

        private void AtualizarSituacaoEmprestimoJogo(int jogoId, bool situacao)
        {
            var jogo = _jogoService.RecuperarPorId(jogoId);
            jogo.IsEmprestado = situacao;
            _jogoService.Atualizar(jogo);
        }

        [HttpGet]
        [Route("RecuperarEmprestimoPorId")]
        public HttpResponseMessage RecuperarEmprestimoPorId(int codigo)
        {
            try
            {
                var retornoModel = new EmprestimoViewModel();

                if (codigo > 0)
                {
                    var emprestimo = _emprestimoService.RecuperarPorId(codigo);
                    if (emprestimo != null)
                        retornoModel = Mapper.Map<Emprestimo, EmprestimoViewModel>(emprestimo);
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
        [Route("FinalizarEmprestimo")]
        public HttpResponseMessage FinalizarEmprestimo(int codigo)
        {
            try
            {
                var retornoModel = new EmprestimoViewModel();

                if (codigo > 0)
                {
                    var emprestimo = _emprestimoService.RecuperarPorId(codigo);
                    if (emprestimo != null)
                    {
                        _emprestimoBusiness.FinalizarEmprestimo(codigo);
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



    }
}

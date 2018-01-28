using GerenciarJogos.Application.Interface;
using GerenciarJogos.Domain.Interface.Services;
using System;
using System.Collections.Generic;

namespace GerenciarJogos.Application.Service
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        #region [CONSTANTES]
        private readonly IServiceBase<TEntity> _serviceBase;

        #endregion

        #region [CONSTRUTOR]
        public AppServiceBase(IServiceBase<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }
        #endregion

        #region [METODOS]
        public void Adicionar(TEntity obj)
        {
            _serviceBase.Adicionar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _serviceBase.Atualizar(obj);
        }

        public IEnumerable<TEntity> BuscarTodos()
        {
            return _serviceBase.BuscarTodos();
        }

        public TEntity RecuperarPorId(int id)
        {
            return _serviceBase.RecuperarPorId(id);
        }

        public void Remover(TEntity obj)
        {
            _serviceBase.Remover(obj);
        }

        #region [DISPOSE]

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _serviceBase.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #endregion

    }
}

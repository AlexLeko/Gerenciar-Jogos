using GerenciarJogos.Domain.Interface.Repositories;
using GerenciarJogos.Domain.Interface.Services;
using System;
using System.Collections.Generic;

namespace GerenciarJogos.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        #region [CONSTANTES]
        private readonly IRepositoryBase<TEntity> _repository;
        #endregion

        #region [CONSTRUTOR]
        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }
        #endregion

        #region [METODOS]
        public void Adicionar(TEntity obj)
        {
            _repository.Adicionar(obj);
        }

        public void Atualizar(TEntity obj)
        {
            _repository.Atualizar(obj);
        }

        public IEnumerable<TEntity> BuscarTodos()
        {
            return _repository.BuscarTodos();
        }

        public TEntity RecuperarPorId(int id)
        {
            return _repository.RecuperarPorId(id);
        }

        public void Remover(TEntity obj)
        {
            _repository.Remover(obj);
        }


        #region [DISPOSE]

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _repository.Dispose();
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

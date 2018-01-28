using GerenciarJogos.Domain.Interface.Repositories;
using GerenciarJogos.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciarJogos.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected GerenciarJogosContext Db = new GerenciarJogosContext();


        public void Adicionar(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
            Db.SaveChanges();
        }

        public void Atualizar(TEntity obj)
        {
            Db.Entry(obj).State = System.Data.Entity.EntityState.Modified;
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> BuscarTodos()
        {
            return Db.Set<TEntity>().ToList();
        }

        public TEntity RecuperarPorId(int id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public void Remover(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
        }


        #region [DISPOSE]

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
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

    }
}

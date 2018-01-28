using System.Collections.Generic;

namespace GerenciarJogos.Domain.Interface.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);

        TEntity RecuperarPorId(int id);

        IEnumerable<TEntity> BuscarTodos();

        void Atualizar(TEntity obj);

        void Remover(TEntity obj);

        void Dispose();
    }
}

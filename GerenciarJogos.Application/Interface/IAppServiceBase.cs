using System.Collections.Generic;

namespace GerenciarJogos.Application.Interface
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        void Adicionar(TEntity obj);

        TEntity RecuperarPorId(int id);

        IEnumerable<TEntity> BuscarTodos();

        void Atualizar(TEntity obj);

        void Remover(TEntity obj);

        void Dispose();
    }
}

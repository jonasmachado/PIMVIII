using System.Collections.Generic;

namespace MyPOS.Dominio.Interfaces.Repositorio
{
    public interface IRepositorioBase<TEntity>
    {
        TEntity Obter(params object[] variaveis);
        List<TEntity> ObterTodos();
        void InserirNovo(TEntity objEntity);
        void RemoverItem(TEntity objEntity);
        void SalvarModificacoes(TEntity objEntity);
        void SalvarModificacoes(List<TEntity> objEntity);
        void InsertOrUpdate(TEntity objEntity);
        int Count();
    }
}

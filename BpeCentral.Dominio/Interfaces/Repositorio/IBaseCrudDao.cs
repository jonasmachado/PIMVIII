using System.Collections.Generic;

namespace BpeCentral.Dominio.Interfaces.Repositorio
{
    public interface IBaseCrudDao<TEntity>
    {
        TEntity Obter(params object[] variaveis);
        List<TEntity> ObterTodos();
        void InserirNovo(TEntity objEntity);
        void RemoverItem(TEntity objEntity);
        void SalvarModificacoes(TEntity objEntity);
        int Count();
    }
}

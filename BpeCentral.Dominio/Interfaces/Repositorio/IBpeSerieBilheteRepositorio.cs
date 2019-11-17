using BpeCentral.Dominio.DTO;
using BpeCentral.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;

namespace BpeCentral.Dominio.Repositorio.Interfaces
{
    public interface ISerieBilheteRepositorio : IBaseCrudDao<BPE_SERIE_BILHETE>
    {
        List<BPE_SERIE_BILHETE> ObterTodos();
        List<BPE_SERIE_BILHETE> ObterTodosOnde(int? aplicacao, int? emitente);
        BPE_SERIE_BILHETE Obter(int id);
    }
}
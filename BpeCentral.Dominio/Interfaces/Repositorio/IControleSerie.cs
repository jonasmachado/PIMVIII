using BpeCentral.Dominio.DTO;
using BpeCentral.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;

namespace BpeCentral.Dominio.Repositorio.Interfaces
{
    public interface IControleSerieRepositorio : IBaseCrudDao<BPE_CONTROLE_SERIE>
    {
        List<BPE_CONTROLE_SERIE> ObterTodos();
        List<BPE_CONTROLE_SERIE> ObterTodosOnde(int? aplicacao, int? emitente);
        BPE_CONTROLE_SERIE Obter(int id);
        BPE_CONTROLE_SERIE Obter(int aplicacao, int emitente);
    }
}
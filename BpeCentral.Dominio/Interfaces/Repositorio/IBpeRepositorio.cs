using BpeCentral.Dominio.DTO;
using BpeCentral.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;

namespace BpeCentral.Dominio.Repositorio.Interfaces
{
    public interface IBpeRepositorio : IBaseCrudDao<BPE_BPES>
    {
        BPE_BPES ObterPorChave(string chave);
    }
}
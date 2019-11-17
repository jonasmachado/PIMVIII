using BpeCentral.Dominio;
using BpeCentral.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;

namespace BpeCentral.Dominio.Repositorio.Interfaces
{
    public interface ISchemaRepositorio : IBaseCrudDao<BPE_SCHEMA>
    {
        void Inserir(BPE_SCHEMA schema);
        BPE_SCHEMA ObterPorNome(string nome);
    }
}

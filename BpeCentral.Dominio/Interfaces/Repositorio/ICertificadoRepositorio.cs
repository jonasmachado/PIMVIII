using BpeCentral.Dominio.DTO;
using BpeCentral.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;

namespace BpeCentral.Dominio.Repositorio.Interfaces
{
    public interface ICertificadoRepositorio : IBaseCrudDao<BPE_CERTIFICADO>
    {
        void Inserir(BPE_CERTIFICADO bpeCertificado);
    }
}
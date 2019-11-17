using BpeCentral.Dominio.DTO;
using BpeCentral.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;

namespace BpeCentral.Dominio.Repositorio.Interfaces
{
    public interface IBpesProcessadosRepositorio : IBaseCrudDao<BPE_PROCESSADO>
    {
        int Count(int codEmitente);
        int Count(int codEmpresa, DateTime data, string codEstado);
        BPE_PROCESSADO Obter(int codEmitente, DateTime data);
        BPE_PROCESSADO ObterXmlPorChave(string chave);
        List<BPE_PROCESSADO> ObterDois(int codEmitente, DateTime data, string codEstado);
        List<BpeEmpresaDTO> RetornaBpesPorEmpresa(int empresa, string codEstado);
        List<BpeEmpresaDTO> RetornaBpesPorEmpresa();
    }
}

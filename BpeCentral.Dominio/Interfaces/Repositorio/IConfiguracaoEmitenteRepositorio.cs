using BpeCentral.Dominio.DTO;
using BpeCentral.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;

namespace BpeCentral.Dominio.Repositorio.Interfaces
{
    public interface IConfiguracaoEmitenteRepositorio : IBaseCrudDao<BPE_CONFIGURACAO_EMITENTE>
    {
        List<BPE_CONFIGURACAO_EMITENTE> ObterTodos();
        List<BPE_CONFIGURACAO_EMITENTE> ObterComDataLimite(DateTime data);
        List<EmpresaCodigoDTO> ObterEmpresasECodigos();
    }
}
using BpeCentral.Dominio;
using BpeCentral.Dominio.DTO;
using BpeCentral.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;

namespace BpeCentral.Dominio.Repositorio.Interfaces
{
    public interface IClienteRepositorio : IBaseCrudDao<BPE_CLIENTE>
    {
        List<ClienteDTO> ObterListaClienteDTO();
    }
}

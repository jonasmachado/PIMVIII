using BpeCentral.Dominio.DTO;
using BpeCentral.Dominio.Interfaces.Repositorio;
using System.Collections.Generic;

namespace BpeCentral.Dominio.Interfaces.Servico
{
    public interface IClienteEmitenteRepositorio : IBaseCrudDao<BPE_CLIENTE_EMITENTE>
    {
        List<ClienteEmitenteDTO> ObterListaClienteEmitenteDTO(int CODIGO_CLIENT);
        void DeleteById(int id);
    }
}

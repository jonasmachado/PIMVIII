using BpeCentral.Dominio;
using BpeCentral.Dominio.DTO;
using BpeCentral.Dominio.Repositorio.Interfaces;
using System.Collections.Generic;
using System.Linq;
using BpeCentral.Dominio.Interfaces.Servico;

namespace BpeCentral.Repositorio.Repositorios
{
    public class ClienteEmitenteRepositorio : BaseCrudDao<BPE_CLIENTE_EMITENTE>, IClienteEmitenteRepositorio
    {
        List<ClienteEmitenteDTO> IClienteEmitenteRepositorio.ObterListaClienteEmitenteDTO(int CODIGO_CLIENTE)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                var sql = "SELECT CE.ID, " +
                          "CE.CODIGO_EMITENTE, " +
                          "CE.CODIGO_CLIENTE, " +
                          "CL.RAZAO_SOCIAL AS NOME_CLIENTE, " +
                          "EM.RAZAO_SOCIAL AS NOME_EMITENTE, " +
                          "EM.UF AS UF_EMITENTE, " +
                          "CL.MUNICIPIO AS MUNICIPIO_CLIENTE " +
                          "FROM BPE_CLIENTE_EMITENTE CE " +
                          "INNER JOIN BPE_CLIENTE CL ON CL.ID = CE.CODIGO_CLIENTE " +
                          "INNER JOIN BPE_CONFIGURACAO_EMITENTE EM ON EM.ID = CE.CODIGO_EMITENTE " +
                          "WHERE CE.CODIGO_CLIENTE = " + CODIGO_CLIENTE;

                return context.Database.SqlQuery<ClienteEmitenteDTO>(sql).ToList();
            }
        }

        public void DeleteById(int id)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                var sql = "DELETE FROM BPE_CLIENTE_EMITENTE WHERE ID = " + id;
                context.Database.ExecuteSqlCommand(sql);
            }
        }
    }
}

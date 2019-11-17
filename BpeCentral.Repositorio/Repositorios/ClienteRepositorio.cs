using BpeCentral.Dominio;
using BpeCentral.Dominio.DTO;
using BpeCentral.Dominio.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BpeCentral.Repositorio.Repositorios
{
    public class ClienteRepositorio : BaseCrudDao<BPE_CLIENTE>, IClienteRepositorio
    {
        List<ClienteDTO> IClienteRepositorio.ObterListaClienteDTO()
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                var sql =   "SELECT C.ID as Id, " +
                            "T.DESCRICAO as TipoCliente, " +
                            "C.RAZAO_SOCIAL as RazaoSocial, " +
                            "C.CNPJ as CNPJ, " +
                            "C.MUNICIPIO as Municipio, " +
                            "C.UF as UF,  " +
                            "C.EMAIL as Email " +
                            "FROM BPE_CLIENTE C " +
                            "LEFT JOIN BPE_TIPO_APLICACAO T ON T.ID = C.TIPO_CLIENTE; ";

                return context.Database.SqlQuery<ClienteDTO>(sql).ToList();
            }
        }        
    }
}

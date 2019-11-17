using System;
using BpeCentral.Dominio;
using BpeCentral.Dominio.Repositorio.Interfaces;
using System.Linq;
using System.Collections.Generic;
using BpeCentral.Dominio.DTO;

namespace BpeCentral.Repositorio.Repositorios
{
    public class ConfiguracaoEmitenteRepositorio : BaseCrudDao<BPE_CONFIGURACAO_EMITENTE>, IConfiguracaoEmitenteRepositorio
    {
        List<BPE_CONFIGURACAO_EMITENTE> IConfiguracaoEmitenteRepositorio.ObterTodos()
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.BPE_CONFIGURACAO_EMITENTE.ToList();
            }
        }

        List<BPE_CONFIGURACAO_EMITENTE> IConfiguracaoEmitenteRepositorio.ObterComDataLimite(DateTime data)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                var sql =   " SELECT * " +
                            " FROM BPE_CONFIGURACAO_EMITENTE e " +
                            " LEFT JOIN BPE_CERTIFICADO cer on cer.CODIGO_CONFIGURACAO_EMITENTE = e.ID " +
                            " WHERE cer.DATA_FINAL <= " + "'" + data.ToString("yyyy-MM-dd") + "'";

                return context.Database.SqlQuery<BPE_CONFIGURACAO_EMITENTE>(sql).ToList();
            }
        }

        public List<EmpresaCodigoDTO> ObterEmpresasECodigos()
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                var sql = "SELECT DISTINCT RAZAO_SOCIAL as Nome, CODIGO_EMPRESA as Codigo FROM BPE_CONFIGURACAO_EMITENTE";

                var ret = context.Database.SqlQuery<EmpresaCodigoDTO>(sql).ToList();
                return ret;
            }
        }
    }
}

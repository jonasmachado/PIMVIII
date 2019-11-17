using System;
using System.Collections.Generic;
using System.Linq;
using BpeCentral.Dominio;
using BpeCentral.Dominio.Repositorio.Interfaces;
using BpeCentral.Dominio.DTO;

namespace BpeCentral.Repositorio.Repositorios
{
    public class BpesProcessados : BaseCrudDao<BPE_PROCESSADO>, IBpesProcessadosRepositorio
    {

        public int Count(int codEmpresa)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                var where = WhereEmpresa(codEmpresa);
                var sql = SqlBpeEmpresa(where);

                return context.Database.SqlQuery<int>(sql).First();
            }
        }


        public int Count(int codEmpresa, DateTime data, string codEstado)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                var where =  WhereEmpresa(codEmpresa);
                    where += WhereDataEmissao(data);
                    where += WhereQuantidadeEnvios(0);
                    where += WhereEstado(codEstado);

                var sql = SqlBpesProcessadosCount(where);

                return context.Database.SqlQuery<int>(sql).First();
            }
        }

        public BPE_PROCESSADO Obter(int codEmpresa, DateTime data)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                var sql = "SELECT * from BPE_PROCESSADO WHERE 1=1";
                    sql += WhereEmpresa(codEmpresa);
                    sql += WhereDataEmissao(data);
                    sql += WhereQuantidadeEnvios(0);

                return context.Database.SqlQuery<BPE_PROCESSADO>(sql).FirstOrDefault();
            }
        }

        public BPE_PROCESSADO ObterXmlPorChave(string chave)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.Set<BPE_PROCESSADO>().FirstOrDefault(p => p.CHAVE.Equals(chave));
            }
        }


        public List<BPE_PROCESSADO> ObterDois(int codEmpresa, DateTime data, string codEstado)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                var where =  WhereEmpresa(codEmpresa);
                    where += WhereDataEmissao(data);
                    where += WhereQuantidadeEnvios(0);
                    where += WhereEstado(codEstado);

                var sql = SqlBpesProcessados(where);

                return context.Database.SqlQuery<BPE_PROCESSADO>(sql).Take(2).ToList();
            }      
        }

        public List<BpeEmpresaDTO> RetornaBpesPorEmpresa()
        {
            return RetornaBpesPorEmpresa(0, "");
        }

        public List<BpeEmpresaDTO> RetornaBpesPorEmpresa(int empresa, string codEstado)
        {
            return new List<BpeEmpresaDTO>();
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                string where = "";

                if (empresa > 0)
                    where += WhereEmpresa(empresa);
                if (codEstado != "")
                    where += WhereEstado(codEstado);

                var sql = SqlBpeEmpresa(where);
                var ret = context.Database.SqlQuery<BpeEmpresaDTO>(sql).ToList();

                ret.Where(p => p.RazaoSocial == null).ToList().ForEach(p => p.RazaoSocial = "OUTROS");

                return ret;
            }
        }

        #region Util
        private string SqlBpesProcessadosCount(string where)
        {
            return "SELECT Count(*) from BPE_PROCESSADO b " +
                   " left join BPE_CONFIGURACAO_EMITENTE c ON c.ID = b.CODIGO_EMITENTE " +
                   " where 1=1 " + where;

        }

        private string SqlBpesProcessados(string where)
        {
            return "SELECT * from BPE_PROCESSADO b " +
                   " left join BPE_CONFIGURACAO_EMITENTE c ON c.ID = b.CODIGO_EMITENTE " +
                   " where 1=1 " + where;

        }
        private string SqlBpeEmpresa(string where)
        {
            return "SELECT Count(*) AS Quantidade, c.RAZAO_SOCIAL AS RazaoSocial from BPE_PROCESSADO b " +
                    " left join BPE_CONFIGURACAO_EMITENTE c ON c.ID = b.CODIGO_EMITENTE " +
                    " where 1=1 " + where + 
                    " group by c.RAZAO_SOCIAL ";
                    
        }
        private string WhereEmpresa(int codEmpresa)
        {
            return " AND c.CODIGO_EMPRESA = " + codEmpresa;
        }

        private string WhereDataEmissao(DateTime data)
        {
            string strData = data.ToString("dd/MM/yyyy");

            return " AND CONVERT(nvarchar(10), DATA_EMISSAO, 103) = " + ComAspasSimples(strData) + " ";
        }

        private string WhereQuantidadeEnvios(int quantidade)
        {
            return " AND QUANTIDADE_ENVIOS = " + quantidade + " ";
        }

        private string WhereEstado(string codEstado)
        {
            return " AND substring(CODIGO_IBGE_ORIGEM,1,2) = " + ComAspasSimples(codEstado) + " ";
        }

        private string ComAspasSimples(string valor)
        {
            return "'" + valor + "'";
        }        
#endregion

    }
}

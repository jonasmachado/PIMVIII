using BpeCentral.Dominio;
using BpeCentral.Dominio.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BpeCentral.Repositorio.Repositorios
{
    public class ControleSerieRepositorio : BaseCrudDao<BPE_CONTROLE_SERIE>, IControleSerieRepositorio
    {
        BPE_CONTROLE_SERIE IControleSerieRepositorio.Obter(int id)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.BPE_CONTROLE_SERIE.Include("BPE_CONFIGURACAO_EMITENTE")
                                                 .Include("BPE_TIPO_APLICACAO")
                                                 .Where(p => p.ID == id).FirstOrDefault(); ;
            }
        }

        BPE_CONTROLE_SERIE IControleSerieRepositorio.Obter(int aplicacao, int emitente)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.BPE_CONTROLE_SERIE.Include("BPE_CONFIGURACAO_EMITENTE")
                                                 .Include("BPE_TIPO_APLICACAO")
                                                 .Where(p => p.CODIGO_TIPO == aplicacao && p.CODIGO_EMITENTE == emitente).FirstOrDefault(); ;
            }
        }

        List<BPE_CONTROLE_SERIE> IControleSerieRepositorio.ObterTodos()
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.BPE_CONTROLE_SERIE.Include("BPE_CONFIGURACAO_EMITENTE")
                                                 .Include("BPE_TIPO_APLICACAO").ToList();
            }
        }

        List<BPE_CONTROLE_SERIE> IControleSerieRepositorio.ObterTodosOnde(int? aplicacao, int? emitente)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                IQueryable<BPE_CONTROLE_SERIE> sql = context.BPE_CONTROLE_SERIE.Include("BPE_CONFIGURACAO_EMITENTE")
                                                    .Include("BPE_TIPO_APLICACAO");

                if (aplicacao != null)
                    sql = sql.Where(p => p.CODIGO_TIPO == aplicacao);
                if (emitente != null)
                    sql = sql.Where(p => p.CODIGO_EMITENTE == emitente);

                return sql.ToList();
            }
        }
    }
}

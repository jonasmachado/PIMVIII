using BpeCentral.Dominio;
using BpeCentral.Dominio.Repositorio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BpeCentral.Repositorio.Repositorios
{
    public class SerieBilheteRepositorio : BaseCrudDao<BPE_SERIE_BILHETE>, ISerieBilheteRepositorio
    {
        BPE_SERIE_BILHETE ISerieBilheteRepositorio.Obter(int id)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.BPE_SERIE_BILHETE.Include("BPE_CONFIGURACAO_EMITENTE")
                                                .Include("BPE_CLIENTE")
                                                .Include("BPE_TIPO_APLICACAO")
                                                .Where(p => p.ID == id).FirstOrDefault();
            }
        }

        List<BPE_SERIE_BILHETE> ISerieBilheteRepositorio.ObterTodos()
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.BPE_SERIE_BILHETE.Include("BPE_CONFIGURACAO_EMITENTE")
                                                .Include("BPE_CLIENTE")
                                                .Include("BPE_TIPO_APLICACAO").ToList();
            }
        }

        List<BPE_SERIE_BILHETE> ISerieBilheteRepositorio.ObterTodosOnde(int? aplicacao, int? emitente)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                IQueryable<BPE_SERIE_BILHETE> sql = context.BPE_SERIE_BILHETE.Include("BPE_CONFIGURACAO_EMITENTE")
                                                .Include("BPE_CLIENTE")
                                                .Include("BPE_TIPO_APLICACAO");

                if (aplicacao != null)
                    sql = sql.Where(p => p.BPE_TIPO_APLICACAO.ID == aplicacao.Value);
                if(emitente != null)
                    sql = sql.Where(p => p.CODIGO_EMITENTE == emitente.Value);

                return sql.ToList();
            }
        }
    }
}

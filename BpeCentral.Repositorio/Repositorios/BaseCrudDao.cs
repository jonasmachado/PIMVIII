using BpeCentral.Dominio;
using BpeCentral.Dominio.Interfaces.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BpeCentral.Repositorio.Repositorios
{
    public class BaseCrudDao<TEntity> : IBaseCrudDao<TEntity> where TEntity : class
    {
        public TEntity Obter(params object[] variaveis)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.Set<TEntity>().Find(variaveis);
            }
        }
        public List<TEntity> ObterTodos()
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.Set<TEntity>().ToList();               
            }
        }

        public void InserirNovo(TEntity objEntity)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                try
                {
                    context.Set<TEntity>().Add(objEntity);
                    context.Entry(objEntity).State = EntityState.Added;
                    context.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void RemoverItem(TEntity objEntity)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                context.Entry(objEntity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void SalvarModificacoes(TEntity objEntity)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                context.Entry(objEntity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public int Count()
        {
            return 0;
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.Set<TEntity>().Count();
            }
        }
    }
}

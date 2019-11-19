using MyPOS.Repositorio.Context;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Linq;
using System.Linq;

namespace MyPOS.Dominio.Interfaces.Repositorio
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        public TEntity Obter(params object[] variaveis)
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                return context.Set<TEntity>().Find(variaveis);
            }
        }

        public List<TEntity> ObterTodos()
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                return context.Set<TEntity>().ToList();
            }
        }

        public void InserirNovo(TEntity objEntity)
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                context.Set<TEntity>().Add(objEntity);
                context.Entry(objEntity).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void InsertOrUpdate(TEntity objEntity)
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                var obj = Obter(objEntity);

                if (obj is null)
                    context.Entry(objEntity).State = EntityState.Added;
                else
                    context.Entry(obj).State = EntityState.Modified;

                context.SaveChanges();
            }
        }

        public void RemoverItem(TEntity objEntity)
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                context.Entry(objEntity).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void SalvarModificacoes(TEntity objEntity)
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                context.Entry(objEntity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void SalvarModificacoes(List<TEntity> objEntity)
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                objEntity.ForEach(e => context.Entry(e).State = EntityState.Modified);
                context.SaveChanges();
            }
        }

        public int Count()
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                return context.Set<TEntity>().Count();
            }
        }

        public virtual TEntity Obter(TEntity obj)
        {
            return null;
        }
    }
}

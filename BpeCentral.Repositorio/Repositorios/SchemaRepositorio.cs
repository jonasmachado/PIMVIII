using System;
using BpeCentral.Dominio;
using BpeCentral.Dominio.Repositorio.Interfaces;
using System.Linq;

namespace BpeCentral.Repositorio.Repositorios
{
    public class SchemaRepositorio : BaseCrudDao<BPE_SCHEMA>, ISchemaRepositorio
    {
        public void Inserir(BPE_SCHEMA schema)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                try
                {
                    context.Database.ExecuteSqlCommand("Insert into BPE_SCHEMA (NOME,REGRAS,DATA_INCLUSAO,DATA_ALTERACAO) values ({0},{1},{2},{3})",
                                                        schema.NOME, schema.REGRAS, schema.DATA_INCLUSAO, schema.DATA_ALTERACAO);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public BPE_SCHEMA ObterPorNome(string nome)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.Set<BPE_SCHEMA>().FirstOrDefault(p => p.NOME.Equals(nome));
            }
        }
    }
}

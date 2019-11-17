using System;
using BpeCentral.Dominio;
using BpeCentral.Dominio.Repositorio.Interfaces;
using System.Linq;

namespace BpeCentral.Repositorio.Repositorios
{
    public class BpeRepositorio : BaseCrudDao<BPE_BPES>, IBpeRepositorio
    {
        public BPE_BPES ObterPorChave(string chave)
        {
            using (BPE_CENTRALEntities context = new BPE_CENTRALEntities())
            {
                return context.Set<BPE_BPES>().FirstOrDefault(p => p.CHAVE.Equals(chave));
            }
        }
    }
}

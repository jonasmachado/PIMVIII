using MyPOS.Dominio.Entidades;
using MyPOS.Dominio.Interfaces.Repositorio;
using MyPOS.Repositorio.Context;
using System;
using System.Linq;

namespace MyPOS.Repositorio.Repositorio
{
    public class TrabalhoRepositorio : RepositorioBase<Trabalho>, ITrabalhoRepositorio
    {
        public int ObterQuantidadeAVencer()
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                return context.Set<Trabalho>().Where(t => t.DataParaEntrega > DateTime.Now && !t.Entregue).Count();
            }
        }

        public int ObterQuantidadeVencidos()
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                return context.Set<Trabalho>().Where(t => t.DataParaEntrega < DateTime.Now && !t.Entregue).Count();
            }
        }

        public int ObterQuantidadeEntregue()
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                return context.Set<Trabalho>().Where(t => t.Entregue).Count();
            }
        }
    }
}

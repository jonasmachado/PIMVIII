using MyPOS.Dominio.Entidades;
using MyPOS.Dominio.Interfaces.Repositorio;
using MyPOS.Repositorio.Context;
using System;
using System.Collections.Generic;
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

        public Trabalho ObterPorId(int id)
        {
            using (MyPOSContext context = new MyPOSContext())
            {
                return context.Set<Trabalho>().FirstOrDefault(a => a.Id_Trabalho == id);
            }
        }
        public List<string> ObterVencendoEmTresDias()
        {
            List<Trabalho> trabalhos;
            var ret = new List<string>();

            using (MyPOSContext context = new MyPOSContext())
            {
                var dataFutura = DateTime.Now.AddDays(3);
                trabalhos = context.Set<Trabalho>()
                    .Where(t => !t.Entregue && 
                    t.DataParaEntrega > DateTime.Now && 
                    t.DataParaEntrega < dataFutura).ToList();
            }

            foreach(var trabalho in trabalhos)
            {
                ret.Add($"A atividade {trabalho.Titulo} vence em ({(int)(trabalho.DataParaEntrega - DateTime.Now).TotalDays}) dias");
            }

            return ret;
        }
    }
}

using MyPOS.Dominio.Entidades;
using System.Collections.Generic;

namespace MyPOS.Dominio.Interfaces.Repositorio
{
    public interface ITrabalhoRepositorio : IRepositorioBase<Trabalho>
    {
        int ObterQuantidadeAVencer();
        int ObterQuantidadeVencidos();
        int ObterQuantidadeEntregue();
        Trabalho ObterPorId(int id);
        List<string> ObterVencendoEmTresDias();
    }
}

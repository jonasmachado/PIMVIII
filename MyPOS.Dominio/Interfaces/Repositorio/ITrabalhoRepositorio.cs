using MyPOS.Dominio.Entidades;

namespace MyPOS.Dominio.Interfaces.Repositorio
{
    public interface ITrabalhoRepositorio : IRepositorioBase<Trabalho>
    {
        int ObterQuantidadeAVencer();
        int ObterQuantidadeVencidos();
        int ObterQuantidadeEntregue();
        Trabalho ObterPorId(int id);
    }
}

using MyPOS.Dominio.Entidades;
using MyPOS.Dominio.Interfaces.Repositorio;
using MyPOS.Repositorio.Context;
using System.Linq;

namespace MyPOS.Repositorio.Repositorio
{
    public class TrabalhoRepositorio : RepositorioBase<Trabalho>, ITrabalhoRepositorio
    {
    }
}

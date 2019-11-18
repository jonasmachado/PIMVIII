using MyPOS.Dominio.Entidades;

namespace MyPOS.Dominio.Interfaces.Repositorio
{
    public interface IUsuarioRepositorio : IRepositorioBase<Usuario>
    {
        Usuario Login(string login, string senha);
        Usuario ObterPorLogin(string login);
        Usuario ObterPorId(int id);
    }
}

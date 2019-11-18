using BpeCentral.Dominio.Interfaces.Repositorio;
using MyPOS.Dominio.Entidades;

namespace BpeCentral.Dominio.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio : IBaseCrudDao<Usuario>
    {
        Usuario Login(string login, string senha);
        Usuario Obter(string email);
        void DeletarUsuario(int id);
    }
}
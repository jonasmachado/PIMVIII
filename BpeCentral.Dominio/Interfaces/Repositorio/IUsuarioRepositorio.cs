using BpeCentral.Dominio.Interfaces.Repositorio;

namespace BpeCentral.Dominio.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio : IBaseCrudDao<BPE_USUARIOS>
    {
        BPE_USUARIOS Login(string login, string senha);
        BPE_USUARIOS Obter(string email);
        int? ObterCodigoEmitente(int id);
        void DeletarUsuario(int id);
    }
}
using BpeCentral.Dominio;
using MyPOS.Dominio.Entidades;

namespace BpeCentral.Dominio.Interfaces.Servico
{
    public interface IUsuarioServico
    {
        Usuario Autenticacao(string login, string senha);
        void MudarStatus(int ID);
        void MudarSenha(Usuario usuario);
        void Alterar(Usuario usuario);
        void Incluir(Usuario usuario);
    }
}

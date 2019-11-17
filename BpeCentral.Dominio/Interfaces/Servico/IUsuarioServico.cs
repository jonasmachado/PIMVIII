using BpeCentral.Dominio;

namespace BpeCentral.Dominio.Interfaces.Servico
{
    public interface IUsuarioServico
    {
        BPE_USUARIOS Autenticacao(string login, string senha);
        void MudarStatus(int ID);
        void MudarSenha(BPE_USUARIOS usuario);
        void Alterar(BPE_USUARIOS usuario);
        void Incluir(BPE_USUARIOS usuario);
    }
}

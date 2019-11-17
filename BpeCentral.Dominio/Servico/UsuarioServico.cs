using BpeCentral.Dominio.Interfaces.Servico;
using BpeCentral.Dominio.Repositorio.Interfaces;
using BpeCentral.Helpers.Properties;

namespace BpeCentral.Dominio.Servico
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio repositorio)
        {
            _usuarioRepositorio = repositorio;
        }

        public BPE_USUARIOS Autenticacao(string login, string senha)
        {
            return _usuarioRepositorio.Login(login, SenhaHelper.GerarHash(senha));
        }

        public void MudarStatus(int ID)
        {
            var usuario = _usuarioRepositorio.Obter(ID);
            if (usuario.ATIVO)
                usuario.ATIVO = false;
            else
                usuario.ATIVO = true;

            _usuarioRepositorio.SalvarModificacoes(usuario);
        }

        public void MudarSenha(BPE_USUARIOS usuario)
        {
            var user = _usuarioRepositorio.Obter(usuario.ID);
            if (user != null)
            {
                user.SENHA = SenhaHelper.GerarHash(usuario.SENHA);
                _usuarioRepositorio.SalvarModificacoes(user);
            }
        }

        //public Maybe<Usuario> TentarAlterar(Usuario novosDados)
        //{
        //    var user = _usuarioRepositorio.Obter(novosDados.ID);

        //    if (user != null)
        //    {
        //        if (user.Email != novosDados.Email &&
        //           EmailJaCadastrado(novosDados.Email))
        //            return Maybe<Usuario>.None("Email já esta em uso.");
        //        else
        //            user.Email = novosDados.Email;
        //        user.Ativo = novosDados.Ativo;
        //        user.Nome = novosDados.Nome;
        //        _usuarioRepositorio.Alterar(user);
        //        return Maybe<Usuario>.Some(user);
        //    }
        //    return Maybe<Usuario>.None("Usuario não encontrado");
        //}

        public void Alterar(BPE_USUARIOS usuario)
        {
            var user = _usuarioRepositorio.Obter(usuario.ID);

            user.ATIVO = usuario.ATIVO;
            user.NOME = usuario.NOME;

            _usuarioRepositorio.SalvarModificacoes(user);
        }

        public void Incluir(BPE_USUARIOS usuario)
        {
            usuario.SENHA = SenhaHelper.GerarHash(usuario.SENHA);
            _usuarioRepositorio.InserirNovo(usuario);
        }

        public bool EmailJaCadastrado(string email)
        {
            return (_usuarioRepositorio.Obter(email) != null);
        }


    }
}

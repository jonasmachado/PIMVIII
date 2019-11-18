using MyPOS.Dominio.Entidades;
using MyPOS.Dominio.Interfaces.Repositorio;
using MyPOS.Dominio.Interfaces.Servicos;
using BpeCentral.Helpers.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPOS.Dominio.Servicos
{
    public class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioServico(IUsuarioRepositorio repositorio)
        {
            _usuarioRepositorio = repositorio;
        }
        
        public Usuario Autenticacao(string login, string senha)
        {
            string hash = SenhaHelper.GerarHash(senha);
            return _usuarioRepositorio.Login(login, hash);
        }

        public void MudarStatus(int ID)
        {
            var usuario = _usuarioRepositorio.Obter(ID);

            _usuarioRepositorio.SalvarModificacoes(usuario);
        }

        public void MudarSenha(Usuario usuario)
        {
            var user = _usuarioRepositorio.Obter(usuario.Id_Usuario);
            if (user != null)
            {
                user.Senha = SenhaHelper.GerarHash(usuario.Senha);
                _usuarioRepositorio.SalvarModificacoes(user);
            }
        }

        public void Alterar(Usuario usuario)
        {
            var user = _usuarioRepositorio.Obter(usuario.Id_Usuario);

            user.Nome = usuario.Nome;

            _usuarioRepositorio.SalvarModificacoes(user);
        }

        public void Incluir(Usuario usuario)
        {
            usuario.Senha = SenhaHelper.GerarHash(usuario.Senha);
            _usuarioRepositorio.InserirNovo(usuario);
        }

        public bool EmailJaCadastrado(string email)
        {
            return (_usuarioRepositorio.Obter(email) != null);
        }

        public Usuario ObterDadosBasicos(string login)
        {
            return _usuarioRepositorio.ObterPorLogin(login);
        }
    }
}

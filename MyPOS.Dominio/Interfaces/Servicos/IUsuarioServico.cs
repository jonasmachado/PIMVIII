using MyPOS.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPOS.Dominio.Interfaces.Servicos
{
    public interface IUsuarioServico
    {
        Usuario Autenticacao(string login, string senha);

        void MudarStatus(int ID);

        void MudarSenha(Usuario usuario);

        void Alterar(Usuario usuario);

        void Incluir(Usuario usuario);

        bool EmailJaCadastrado(string email);

        Usuario ObterDadosBasicos(string login);

    }
}

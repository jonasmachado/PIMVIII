using System;
using AutoMapper;

using HomeworkBuddy.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using HomeworkBuddy.Web.Filters;
using HomeworkBuddy.Web.Model;
using HomeworkBuddy.Web.Helpers;
using HomeworkBuddy.Dominio.Comum.Enum;
using HomeworkBuddy.Dominio;
using System.Linq;
using MyPOS.Dominio.Interfaces.Repositorio;
using MyPOS.Dominio.Interfaces.Servicos;
using MyPOS.Dominio.Entidades;

namespace HomeworkBuddy.Web.Controllers
{
    [ExceptionHandleError]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IUsuarioServico _usuarioServico;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio, IUsuarioServico usuarioServico)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioServico = usuarioServico;
        }

        [SessionAuthorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            var vm = new List<UsuarioViewModel>();
            var result = _usuarioRepositorio.ObterTodos();
            if (result != null && result.Count > 0)
                vm = Mapper.Map<List<Usuario>, List<UsuarioViewModel>>(result);
            return View(vm);
        }


        [SessionAuthorize(Roles = "Administrador")]
        public ActionResult Cadastro(int? id)
        {
            var vm = new UsuarioViewModel();
            if (id > 0)
            {
                var result = _usuarioRepositorio.ObterPorId(id.Value);
                if (result != null && result.Id_Usuario > 0)
                    vm = Mapper.Map<Usuario, UsuarioViewModel>(result);
            }
            else
            {                      
                var user = SessionHelperWeb.RecuperarUsuario();
                vm.Perfil = 1;
            }
            return View(vm);
        }

        [HttpPost]
        [SessionAuthorize(Roles = "Administrador")]
        public ActionResult Cadastro(UsuarioViewModel user) 
        {
            var usuario = Mapper.Map<UsuarioViewModel, Usuario>(user);
            if (user.Id_Usuario > 0)
            {
                _usuarioServico.Alterar(usuario);
            }   
            else
            {
                if (EmailJaCadastrado(user.Email))
                    return View().ComMensagem(StatusSistemaEnum.Erro, new string[] { "Email já cadastrado" });

                _usuarioServico.Incluir(usuario);
            }

            return RedirectToAction("Index", "Painel").ComMensagem(StatusSistemaEnum.Sucesso);
        }

        [SessionAuthorize(Roles = "Administrador, EmpresaDeTransporte, ClienteEmpresa")]
        public ActionResult MudarSenha(int id)
        {
            UsuarioViewModel vm = new UsuarioViewModel();
            if (id > 0)
            {
                var result = _usuarioRepositorio.Obter(id);
                if (result != null && result.Id_Usuario > 0)
                    vm = Mapper.Map<Usuario, UsuarioViewModel>(result);
            }
            else
                return View().ComMensagem(StatusSistemaEnum.Erro, new string[] { "erro" });
            return View(vm);
        }

        [HttpPost]
        [SessionAuthorize(Roles = "Administrador, EmpresaDeTransporte, ClienteEmpresa")]
        public ActionResult MudarSenha(UsuarioViewModel user)
        {
            var usuario = Mapper.Map<UsuarioViewModel, Usuario>(user);

            if (user.Id_Usuario > 0)
                _usuarioServico.MudarSenha(usuario);
            else
                return View().ComMensagem(StatusSistemaEnum.Erro, new string[] { "erro" });
            return RedirectToAction("Index", "Painel").ComMensagem(StatusSistemaEnum.Sucesso);
        }

        [SessionAuthorize(Roles = "Administrador, EmpresaDeTransporte, ClienteEmpresa")]
        public ActionResult MudarStatus(int id)
        {
            if (id > 0)
                _usuarioServico.MudarStatus(id);
            return RedirectToAction("Index").ComMensagem(StatusSistemaEnum.Sucesso);
        }

        [SessionAuthorize(Roles = "Administrador")]
        public ActionResult Delete(int id)
        {
            var usuario = _usuarioRepositorio.ObterPorId(id);
            _usuarioRepositorio.RemoverItem(usuario);
            return RedirectToAction("Index").ComMensagem(StatusSistemaEnum.Sucesso);
        }

        //MOCK
        public bool EmailJaCadastrado(string email)
        {
            return false;
        }

        /*
        public bool EmailJaCadastrado(string email)
        {
            return (_usuarioRepositorio.Obter(email) != null);
        }*/
    }
}
using System;
using AutoMapper;

using BpeCentral.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;
using BpeCentral.Dominio.Interfaces.Servico;
using BpeCentral.Dominio.Repositorio.Interfaces;
using BpeCentral.Web.Filters;
using BpeCentral.Web.Model;
using BpeCentral.Web.Helpers;
using BpeCentral.Dominio.Comum.Enum;
using BpeCentral.Dominio;
using System.Linq;

namespace BpeCentral.Web.Controllers
{
    [ExceptionHandleError]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;
        private readonly IUsuarioServico _usuarioServico;
        private readonly IClienteRepositorio _clienteRespositorio;
        private readonly IConfiguracaoEmitenteRepositorio _ConfigEmitenteRepositorio;

        public UsuariosController(IUsuarioRepositorio usuarioRepositorio, IUsuarioServico usuarioServico, IClienteRepositorio clienteRespositorio, IConfiguracaoEmitenteRepositorio ConfigEmitenteRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
            _usuarioServico = usuarioServico;
            _clienteRespositorio = clienteRespositorio;
            _ConfigEmitenteRepositorio = ConfigEmitenteRepositorio;
        }

        [SessionAuthorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            var vm = new List<UsuarioViewModel>();
            var result = _usuarioRepositorio.ObterTodos();
            if (result != null && result.Count > 0)
                vm = Mapper.Map<List<BPE_USUARIOS>, List<UsuarioViewModel>>(result);
            return View(vm);
        }


        [SessionAuthorize(Roles = "Administrador")]
        public ActionResult Cadastro(int? id)
        {
            var vm = new UsuarioViewModel();
            ViewBag.EmpresasCodigos = _ConfigEmitenteRepositorio.ObterEmpresasECodigos(); ;
            if (id > 0)
            {
                var result = _usuarioRepositorio.Obter(id);
                if (result != null && result.ID > 0)
                    vm = Mapper.Map<BPE_USUARIOS, UsuarioViewModel>(result);
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
            var usuario = Mapper.Map<UsuarioViewModel, BPE_USUARIOS>(user);
            if (user.ID > 0)
            {
                //var userMaybe = _usuarioServico.TentarAlterar(usuario);
                //if (!userMaybe.HasValue)
                //    return RedirectToAction("Cadastro", usuario.ID).ComMensagem(StatusSistemaEnum.Erro, userMaybe.Notificacao);
            }   //
            else
            {
                //if (EmailJaCadastrado(user.Email))
                //    return View().ComMensagem(StatusSistemaEnum.Erro, new string[] { UsuarioExcecao.MensagensValidacao.EmailEmUso });
                usuario.DATA_CADASTRO = DateTime.Now;
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
                if (result != null && result.ID > 0)
                    vm = Mapper.Map<BPE_USUARIOS, UsuarioViewModel>(result);
            }
            else
                return View().ComMensagem(StatusSistemaEnum.Erro, new string[] { "erro" });
            return View(vm);
        }

        [HttpPost]
        [SessionAuthorize(Roles = "Administrador, EmpresaDeTransporte, ClienteEmpresa")]
        public ActionResult MudarSenha(UsuarioViewModel user)
        {
            var usuario = Mapper.Map<UsuarioViewModel, BPE_USUARIOS>(user);

            if (user.ID > 0)
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
            _usuarioRepositorio.DeletarUsuario(id);
            return RedirectToAction("Index").ComMensagem(StatusSistemaEnum.Sucesso);
        }

        public bool EmailJaCadastrado(string email)
        {
            return (_usuarioRepositorio.Obter(email) != null);
        }
    }
}
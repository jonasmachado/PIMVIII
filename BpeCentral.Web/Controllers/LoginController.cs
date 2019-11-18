using System.Web.Mvc;
using System.Web.Security;
using BpeCentral.Dominio;
using BpeCentral.Dominio.Comum.Enum;
using BpeCentral.Helpers;
using BpeCentral.Web.Model;
using BpeCentral.Web.ViewModels;
using System;
using System.Collections.Generic;
using MyPOS.Dominio.Interfaces.Servicos;
using MyPOS.Dominio.Entidades;

namespace BpeCentral.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IUsuarioServico _usuarioServico;

        public LoginController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            var autenticacao = _usuarioServico.Autenticacao(model.Email, model.Senha);

            if (autenticacao is null)
            {
                return View().ComMensagem(StatusSistemaEnum.Erro, new string[] { "Usuario ou Senha Incorretos" });
            }
            return LoginEReturnToPerfil(autenticacao);           
        }

        private ActionResult LoginEReturnToPerfil(Usuario usuario)
        {
            FormsAuthentication.SetAuthCookie(usuario.Email, false);
            SessionHelper.Adicionar("dataOn", usuario);
            SessionHelper.Adicionar("Estado", "RS");
            
            return RedirectToAction("Index", "Painel");
        }
        
        public ActionResult RecuperarSenha()
        {
            return View();
        }
      
        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            SessionHelper.Remover("dataOn");
            SessionHelper.Remover("Token");
            return RedirectToAction("Index", "Login");
        }
    }
}
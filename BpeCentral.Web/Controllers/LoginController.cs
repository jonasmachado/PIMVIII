using System.Web.Mvc;
using System.Web.Security;
using BpeCentral.Dominio;
using BpeCentral.Dominio.Comum.Enum;

using BpeCentral.Dominio.Interfaces.Servico;
using BpeCentral.Helpers;
using BpeCentral.Web.Model;
using BpeCentral.Web.ViewModels;
using System;
using BpeCentral.Dominio.DTO;
using System.Collections.Generic;
using BpeCentral.Dominio.Comum.Enums;

namespace BpeCentral.Web.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private IUsuarioServico _usuarioServico;
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public LoginController(IUsuarioServico usuarioServico)
        {
            _usuarioServico = usuarioServico;
        }

        public ActionResult Index()
        {
            var valores = Enum.GetValues(typeof(EstadoEnum));
            List<EstadoCodigoDTO> lst = new List<EstadoCodigoDTO>();

            foreach(var item in valores)
            {
                lst.Add(new EstadoCodigoDTO { Codigo = (int)item, Estado = item.ToString()});
            }

            ViewBag.Estados = lst;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            return LoginEReturnToPerfil(/*autenticacao, "" +(int)model.UF.Value*/ null, "1");



             var autenticacao = _usuarioServico.Autenticacao(model.Email, model.Senha);

            if(model.UF == 0)
                return View().ComMensagem(StatusSistemaEnum.Erro, new string[] { "Necessário informar o estado" });

            if (autenticacao != null)
            {
                return LoginEReturnToPerfil(/*autenticacao, "" +(int)model.UF.Value*/ null, "1");
            }
            return View().ComMensagem(StatusSistemaEnum.Erro, new string[] { "Usuario ou Senha Incorretos" });
        }

        private ActionResult LoginEReturnToPerfil(BPE_USUARIOS usuario, string CodEstado)
        {
            FormsAuthentication.SetAuthCookie("qqq@sd.com", false);
            SessionHelper.Adicionar("dataOn", new BPE_USUARIOS { EMAIL = "qqq@sd.com", ID = 0, NOME = "abc", PERFIL = 1});
            SessionHelper.Adicionar("Estado", "RS");
            
            return RedirectToAction("Index", "Painel");
        }

        public ActionResult RecuperarSenha()
        {
            return View();
        }
      
        public ActionResult Sair()
        {
            var user = SessionHelper.Recuperar<BPE_USUARIOS>("dataOn");
            if (user != null)
                logger.Info(user.PERFIL.ToString() + ") " + user.NOME + " saiu do sistema.");
            FormsAuthentication.SignOut();
            SessionHelper.Remover("dataOn");
            SessionHelper.Remover("Token");
            return RedirectToAction("Index", "Login");
        }
    }
}
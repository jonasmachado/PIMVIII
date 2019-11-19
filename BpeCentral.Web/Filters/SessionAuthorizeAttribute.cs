using System;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using HomeworkBuddy.Dominio;
using HomeworkBuddy.Dominio.Comum.Enum;

using HomeworkBuddy.Helpers;
using HomeworkBuddy.Web.Model;
using HomeworkBuddy.Web.ViewModels;
//using HomeworkBuddy.Dominio.Enum;

namespace HomeworkBuddy.Web.Filters
{
    public class SessionAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            /*var regras = this.Roles.Split(',');

            BPE_USUARIOS result = SessionHelper.Recuperar<BPE_USUARIOS>("dataOn");
            UsuarioViewModel usuario = Mapper.Map<BPE_USUARIOS, UsuarioViewModel>(result);

            if (usuario == null)
                return false;

            foreach(EPerfilUsuario perfil in Enum.GetValues(typeof(EPerfilUsuario)))
            {
                foreach(string regra in regras)
                {
                    if(Enum.GetName(typeof(EPerfilUsuario), (int)perfil).Equals(regra))
                        return true;
                }
            }
            */
            return true;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            HttpContext.Current.Session.Clear();
            filterContext.Result = new RedirectResult("/Login").ComMensagem(StatusSistemaEnum.Erro, new string[] { "Acesso negado." });
        }
    }
}
using System;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using HomeworkBuddy.Dominio;
using HomeworkBuddy.Dominio.Comum.Enum;

using HomeworkBuddy.Helpers;
using HomeworkBuddy.Web.Model;
using HomeworkBuddy.Web.ViewModels;
using MyPOS.Dominio.Entidades;
//using HomeworkBuddy.Dominio.Enum;

namespace HomeworkBuddy.Web.Filters
{
    public class SessionAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {

            var result = SessionHelper.Recuperar<Usuario>("dataOn");
            UsuarioViewModel usuario = Mapper.Map<Usuario, UsuarioViewModel>(result);

            return usuario != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            HttpContext.Current.Session.Clear();
            filterContext.Result = new RedirectResult("/Login").ComMensagem(StatusSistemaEnum.Erro, new string[] { "Acesso negado." });
        }
    }
}
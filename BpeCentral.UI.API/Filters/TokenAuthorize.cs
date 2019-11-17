using BpeCentral.API.Tokenizacao;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace BpeCentral.API.Filters
{
    public class TokenAuthorize : AuthorizeAttribute
    {
        string msgError = "";
        bool autenticado = false;
        //TODO : se nao autenticado retorna 401 se nao autorizado 403

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            autenticado = false;
            AuthenticationHeaderValue authorization = actionContext.Request.Headers.Authorization;
            if (authorization == null)
            {
                msgError = "necessária autorização";
                return false;
            }

            if (authorization.Scheme != "Bearer")
            {
                msgError = "authorization deve ser Bearer";
                return false;
            }

            if (string.IsNullOrWhiteSpace(authorization.Parameter))
            {
                msgError = "falha no token";
                return false;
            }


            Token token = new Token();
            var stoken = token.ConvertToken(authorization.Parameter);
            if (stoken == null)
            {
                msgError = "token invalido";
                return false;
            }

            if (stoken.ValidTo < DateTime.UtcNow)
            {
                msgError = " token expirado";
                return false;
            }
            var codEmpresa = stoken.Claims.FirstOrDefault(x => x.Type == "codEmpresa");
            if (codEmpresa == null)
            {
                msgError = "token invalido - codEmpresa";
                return false;
            }

            var estado = stoken.Claims.FirstOrDefault(x => x.Type == "Estado");
            int codEstado = 0;
            if (Int32.TryParse(estado.Value, out codEstado) && codEstado == 0)
            {
                msgError = "token invalido - Estado";
                return false;
            }

            var userId = stoken.Claims.FirstOrDefault(x => x.Type == "UserId");
            if (userId == null)
            {
                msgError = "token invalido - user";
                return false;
            }
            var identity = new GenericIdentity(userId.Value);
            identity.AddClaims(stoken.Claims);

            SetPrincipal(new GenericPrincipal(identity, new string[] { codEmpresa.ToString() }));
            return true;

        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage
            {
                StatusCode = autenticado ? HttpStatusCode.Forbidden : HttpStatusCode.Unauthorized,
                Content = new StringContent(msgError)
            };

            if (!autenticado)
                HttpContext.Current.Response.AppendHeader("WWW-Authenticate", "Bearer");
        }

        private static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }

    }
}
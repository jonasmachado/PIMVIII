using BpeCentral.Dominio;
using BpeCentral.Helpers;

namespace BpeCentral.Web.Helpers
{
    public static class SessionHelperWeb
    { 
        public static BPE_USUARIOS RecuperarUsuario()
        {
            return  SessionHelper.Recuperar<BPE_USUARIOS>("dataOn");
        }
    }
}
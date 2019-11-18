using BpeCentral.Helpers;
using MyPOS.Dominio.Entidades;

namespace BpeCentral.Web.Helpers
{
    public static class SessionHelperWeb
    { 
        public static Usuario RecuperarUsuario()
        {
            return  SessionHelper.Recuperar<Usuario>("dataOn");
        }
    }
}
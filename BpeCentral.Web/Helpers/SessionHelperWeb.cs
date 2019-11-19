using HomeworkBuddy.Helpers;
using MyPOS.Dominio.Entidades;

namespace HomeworkBuddy.Web.Helpers
{
    public static class SessionHelperWeb
    { 
        public static Usuario RecuperarUsuario()
        {
            return  SessionHelper.Recuperar<Usuario>("dataOn");
        }
    }
}
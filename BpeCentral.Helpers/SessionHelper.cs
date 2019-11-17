using System;
using System.Web;

namespace BpeCentral.Helpers
{
    public static class SessionHelper
    {
        public static HttpContext Current => HttpContext.Current;

        public static void Adicionar<T>(string chave, T obj) where T : class
        {
            Current.Session[chave] = obj;
        }

        public static void Remover(string chave)
        {
            Current.Session.Remove(chave);
        }

        public static void Excluir()
        {
            Current.Session.Clear();
        }

        public static bool Existe(string chave)
        {
            return Current.Session?[chave] != null && !string.IsNullOrEmpty(chave);
        }

        public static T Recuperar<T>(string chave) where T : class
        {
            return Current.Session[chave] as T;
        }
    }
}

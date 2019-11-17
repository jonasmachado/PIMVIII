using System.Text.RegularExpressions;

namespace BpeCentral.Helpers
{
    public static class StringHelper
    {
        public static string SomenteNumeros(this string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                Regex regexObj = new Regex(@"[^\d]");
                return regexObj.Replace(valor, "");
            }

            return valor;
        }
    }
}

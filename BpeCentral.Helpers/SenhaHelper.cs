using System;
using System.Security.Cryptography;
using System.Text;

namespace BpeCentral.Helpers.Properties
{
    public static class SenhaHelper
    {
        public static string GerarHash(string senha)
        {
            try
            {
                MD5 md5 = System.Security.Cryptography.MD5.Create();
                byte[] inputBytes = Encoding.ASCII.GetBytes(senha);
                byte[] hash = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString(); // Retorna senha criptografada 
            }
            catch (Exception)
            {
                return null; // Caso encontre erro retorna nulo
            }
        }

    }
}

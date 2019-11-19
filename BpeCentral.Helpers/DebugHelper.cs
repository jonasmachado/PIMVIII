using System;

namespace HomeworkBuddy.Helpers
{
    public static class DebugHelper
    {
        public static void Debug(string Valor, string titulo, string formato = "txt")
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("/Logs/" + titulo + "_" + DateTime.Now.Year + '-' + DateTime.Now.Month + '-' + DateTime.Now.Day + "." + formato);

            try
            {
                if (!System.IO.File.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("/Logs"));
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(path))
                    {
                        sw.WriteLine(Valor);
                    }
                }
                else
                {
                    using (System.IO.StreamWriter sw = System.IO.File.AppendText(path))
                    {
                        sw.WriteLine(Valor);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }
    }
}

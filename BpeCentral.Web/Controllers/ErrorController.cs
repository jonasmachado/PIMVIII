using System.Web.Mvc;

namespace BpeCentral.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult NaoEncontrado()
        {
            Response.StatusCode = 404;
            return View();
        }

        public ActionResult ErroServidor()
        {
            Response.StatusCode = 505;
            return View();
        }
    }
}
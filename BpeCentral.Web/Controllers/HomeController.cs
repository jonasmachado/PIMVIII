using System;
using System.Web.Mvc;
using BpeCentral.Web.Filters;

namespace BpeCentral.Web.Controllers
{
    [ExceptionHandleError]
    public class HomeController : Controller
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            return View();
        }
    }
}

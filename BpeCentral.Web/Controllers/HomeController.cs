using System;
using System.Web.Mvc;
using HomeworkBuddy.Web.Filters;

namespace HomeworkBuddy.Web.Controllers
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

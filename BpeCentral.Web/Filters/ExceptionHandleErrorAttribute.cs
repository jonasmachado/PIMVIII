using System;
using System.Linq;
using System.Web.Mvc;
using BpeCentral.Dominio.Comum.Enum;
using BpeCentral.Helpers;
using BpeCentral.Web.Model;

namespace BpeCentral.Web.Filters
{
    public class ExceptionHandleErrorAttribute : HandleErrorAttribute, IExceptionFilter
    {
        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            foreach (var modelValue in ((Controller)filterContext.Controller).ModelState.Values)
            {
                modelValue.Errors.Clear();
            }

            ((Controller)filterContext.Controller).ModelState.AddModelError("", filterContext.Exception.Message);
            
            string actionName = Convert.ToString(filterContext.RouteData.Values.Values.ElementAt(0));
            string viewName = Convert.ToString(filterContext.RouteData.Values.Values.ElementAt(1));            
            ViewEngineResult resultado = ViewEngines.Engines.FindView(filterContext.Controller.ControllerContext, viewName, null);
            
            ViewResult viewResult = new ViewResult
            {
                ViewName = viewName,
                TempData = filterContext.Controller.TempData,
                ViewData = filterContext.Controller.ViewData
            };

            
            logger.Error(filterContext.Exception.Message);
            if (!string.IsNullOrWhiteSpace(filterContext.Exception.Message.ToString()))
                filterContext.Result = viewResult.ComMensagem(StatusSistemaEnum.Erro, new string[] { filterContext.Exception.Message });
            else
                filterContext.Result = viewResult.ComMensagem(StatusSistemaEnum.Erro);
            
            base.OnException(filterContext);
        }
    }
}
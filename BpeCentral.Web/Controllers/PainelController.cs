using System.Web.Mvc;
using BpeCentral.Web.Filters;
using BpeCentral.Web.ViewModels;
using BpeCentral.Dominio;
using AutoMapper;
using BpeCentral.Helpers;
using System;

namespace BpeCentral.Web.Controllers
{
    [ExceptionHandleError]
    public class PainelController : Controller
    {

        public PainelController()
        {
        }                     
        
        [SessionAuthorize(Roles = "Administrador,Empresa de Transporte")]
        public ActionResult Index()
        {
            ViewBag.Estado = 0;
            PainelViewModel vm = new PainelViewModel();
            return View(vm);
        }

        private PainelViewModel MontaDadosPainel()
        {
            return new PainelViewModel();
        }
    }
}
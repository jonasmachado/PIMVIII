using System.Web.Mvc;
using System.Web.Security;
using BpeCentral.Dominio;
using BpeCentral.Dominio.Comum.Enum;
using BpeCentral.Helpers;
using BpeCentral.Web.Model;
using BpeCentral.Web.ViewModels;
using System;
using System.Collections.Generic;
using MyPOS.Dominio.Interfaces.Servicos;
using MyPOS.Dominio.Entidades;
using MyPOS.Dominio.Interfaces.Repositorio;

namespace BpeCentral.Web.Controllers
{
    [AllowAnonymous]
    public class TrabalhoController : Controller
    {
        private ITrabalhoRepositorio _trabalhoRepositorio;
        public TrabalhoController(ITrabalhoRepositorio trabalhoRepositorio)
        {
            _trabalhoRepositorio = trabalhoRepositorio;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }
    }
}
﻿using System.Web.Mvc;
using BpeCentral.Web.Filters;
using BpeCentral.Web.ViewModels;
using BpeCentral.Dominio;
using AutoMapper;
using BpeCentral.Helpers;
using System;
using MyPOS.Dominio.Interfaces.Repositorio;

namespace BpeCentral.Web.Controllers
{
    [ExceptionHandleError]
    public class PainelController : Controller
    {
        private ITrabalhoRepositorio _trabalhoRepositorio;
        public PainelController(ITrabalhoRepositorio trabalhoRepositorio)
        {
            _trabalhoRepositorio = trabalhoRepositorio;
        }

        [SessionAuthorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            ViewBag.Alertas = _trabalhoRepositorio.ObterVencendoEmTresDias();
            var vm = MontaDadosPainel();
            return View(vm);
        }

        private PainelViewModel MontaDadosPainel()
        {
            return new PainelViewModel()
            {
                TotalTrabalhos     = _trabalhoRepositorio.Count(),
                TrabalhosEntregues = _trabalhoRepositorio.ObterQuantidadeEntregue(),
                TrabalhosVencidos  = _trabalhoRepositorio.ObterQuantidadeVencidos()
            };
        }
    }
}
﻿using System.Web.Mvc;
using System.Web.Security;
using HomeworkBuddy.Dominio;
using HomeworkBuddy.Dominio.Comum.Enum;
using HomeworkBuddy.Helpers;
using HomeworkBuddy.Web.Model;
using HomeworkBuddy.Web.ViewModels;
using System;
using System.Collections.Generic;
using MyPOS.Dominio.Interfaces.Servicos;
using MyPOS.Dominio.Entidades;
using MyPOS.Dominio.Interfaces.Repositorio;
using AutoMapper;
using HomeworkBuddy.Web.Filters;

namespace HomeworkBuddy.Web.Controllers
{
    [AllowAnonymous]
    public class TrabalhoController : ControllerBase
    {
        private ITrabalhoRepositorio _trabalhoRepositorio;
        public TrabalhoController(ITrabalhoRepositorio trabalhoRepositorio)
        {
            _trabalhoRepositorio = trabalhoRepositorio;
        }

        [SessionAuthorize]
        public ActionResult Index()
        {
            var colecao = Listagem<TrabalhoViewModel, Trabalho, ITrabalhoRepositorio>(_trabalhoRepositorio);
            return View(colecao);
        }

        [SessionAuthorize]
        public ActionResult Cadastro(int? id)
        {
            var vm = new TrabalhoViewModel();
            if (id > 0)
            {
                var result = _trabalhoRepositorio.ObterPorId(id.Value);
                if (result != null && result.Id_Trabalho > 0)
                    vm = Mapper.Map<Trabalho, TrabalhoViewModel>(result);
            }
 
            return View(vm);
        }

        [SessionAuthorize]
        [HttpPost]
        public ActionResult Cadastro(TrabalhoViewModel trabalho)
        {
            if(trabalho.Id_Trabalho == 0)
                Cadastrar<TrabalhoViewModel, Trabalho, ITrabalhoRepositorio>(_trabalhoRepositorio, trabalho);
            else
            {
                var entity = Mapper.Map<TrabalhoViewModel, Trabalho>(trabalho);
                _trabalhoRepositorio.SalvarModificacoes(entity);
            }
            return RedirectToAction("Index", "Painel").ComMensagem(StatusSistemaEnum.Sucesso);
        }

        public ActionResult Delete(int id)
        {
            var trabalho = _trabalhoRepositorio.ObterPorId(id);
            _trabalhoRepositorio.RemoverItem(trabalho);

            return RedirectToAction("Index", "Painel").ComMensagem(StatusSistemaEnum.Sucesso);
        }

        public ActionResult MudarStatus(int id)
        {
            if (id == 0)
                return RedirectToAction("Index").ComMensagem(StatusSistemaEnum.Erro, new string[] { "Não foi possível alterar o Status "});

            var trabalho = _trabalhoRepositorio.ObterPorId(id);
                trabalho.Entregue = !trabalho.Entregue;
                _trabalhoRepositorio.SalvarModificacoes(trabalho);
            
            return RedirectToAction("Index").ComMensagem(StatusSistemaEnum.Sucesso);
        }
    }
}
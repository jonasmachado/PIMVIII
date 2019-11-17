using System.Web.Mvc;
using BpeCentral.Web.Filters;
using BpeCentral.Web.ViewModels;
using BpeCentral.Dominio.Interfaces.Servico;
using BpeCentral.Dominio.Model;
using BpeCentral.Dominio;
using AutoMapper;
using BpeCentral.Helpers;
using BpeCentral.Dominio.Enum;
using BpeCentral.Dominio.Comum.Enums;
using System;

namespace BpeCentral.Web.Controllers
{
    [ExceptionHandleError]
    public class PainelController : Controller
    {
        IPainelServico _painelServico;

        public PainelController(IPainelServico painelServico)
        {
            _painelServico = painelServico;
        }                                       
        [SessionAuthorize(Roles = "Administrador,Empresa de Transporte")]
        public ActionResult Index()
        {
            EstadoEnum estado;
            Enum.TryParse(SessionHelper.Recuperar<string>("Estado"), out estado);
            ViewBag.Estado = estado;
            PainelViewModel vm = MontaDadosPainel();
            return View(vm);
        }

        private PainelViewModel MontaDadosPainel()
        {
            BPE_USUARIOS result = SessionHelper.Recuperar<BPE_USUARIOS>("dataOn");
            UsuarioViewModel usuario = Mapper.Map<BPE_USUARIOS, UsuarioViewModel>(result);
            PainelViewModel ret = new PainelViewModel();
            PainelModel model;
            string estado = SessionHelper.Recuperar<string>("Estado");

            if (usuario.Perfil == (int)EPerfilUsuario.Administrador)
            {
                model = _painelServico.RetornaDadosPainelAdministrador();
                ret.Perfil = (EPerfilUsuario)usuario.Perfil; 
                
            }
            else
            {

                model = _painelServico.RetornaDadosPainelUsuario(result.CODIGO_EMPRESA.Value, estado);
            }

            MapPainelViewModel(ret, model);

            return ret;
        }

        private void MapPainelViewModel(PainelViewModel vm, PainelModel m)
        {
            vm.BpesProcessados = m.BpesProcessados;
            vm.Empresas = m.Empresas;
            vm.EmpresaQuantidadeBpe = m.EmpresaQuantidadeBpe;
            vm.Usuarios = m.Usuarios;
        }
    }
}
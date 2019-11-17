using System;
using BpeCentral.Dominio.Interfaces.Servico;
using BpeCentral.Dominio.Repositorio.Interfaces;
using BpeCentral.Helpers.Properties;
using BpeCentral.Dominio.Model;
using BpeCentral.Dominio.Enum;
using BpeCentral.Dominio.DTO;
using System.Collections.Generic;

namespace BpeCentral.Dominio.Servico
{
    public class PainelServico : IPainelServico
    {
        IUsuarioRepositorio _usuariosRepositorio;
        IBpesProcessadosRepositorio _bpesProcessadosRepositorio;
        IConfiguracaoEmitenteRepositorio _configuracaoEmitenteRepositorio;

        public PainelServico(IUsuarioRepositorio usuariosRepositorio, IBpesProcessadosRepositorio bpesProcessadosRepositorio, IConfiguracaoEmitenteRepositorio configuracaoEmitenteRepositorio)
        {
            _usuariosRepositorio = usuariosRepositorio;
            _bpesProcessadosRepositorio = bpesProcessadosRepositorio;
            _configuracaoEmitenteRepositorio = configuracaoEmitenteRepositorio;
        }

        public PainelModel RetornaDadosPainelAdministrador()
        {
            PainelModel ret = new PainelModel();

            ret.Usuarios = _usuariosRepositorio.Count();
            ret.BpesProcessados = _bpesProcessadosRepositorio.Count();
            ret.Empresas = _configuracaoEmitenteRepositorio.Count();
            ret.EmpresaQuantidadeBpe = _bpesProcessadosRepositorio.RetornaBpesPorEmpresa();

            return ret;
        }
        public PainelModel RetornaDadosPainelUsuario(int codEmpresa, string codEstado)
        {
            PainelModel ret = new PainelModel();

            ret.Usuario = EPerfilUsuario.EmpresaDeTransporte;
            ret.EmpresaQuantidadeBpe = _bpesProcessadosRepositorio.RetornaBpesPorEmpresa(codEmpresa, codEstado);
            return ret;
        }

    }
}

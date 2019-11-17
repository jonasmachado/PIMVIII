using BpeCentral.Dominio.DTO;
using BpeCentral.Dominio.Enum;
using System.Collections.Generic;

namespace BpeCentral.Web.ViewModels
{
    public class PainelViewModel
    {
        public int Usuarios { get; set; }
        public EPerfilUsuario Perfil { get; set; }
        public int Empresas { get; set; }
        public int BpesProcessados { get; set; }
        public List<BpeEmpresaDTO> EmpresaQuantidadeBpe { get; set; }
    }
}
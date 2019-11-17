using BpeCentral.Dominio.DTO;
using BpeCentral.Dominio.Enum;
using System.Collections.Generic;

namespace BpeCentral.Dominio.Model
{
    public class PainelModel
    {
        public int Usuarios { get; set; }
        public int Empresas { get; set; }
        public int BpesProcessados { get; set; }
        public EPerfilUsuario Usuario { get; set; }
        public List<BpeEmpresaDTO> EmpresaQuantidadeBpe { get; set; }
    }
}
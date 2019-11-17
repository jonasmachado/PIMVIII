using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BpeCentral.Dominio.Enum
{
    public enum EPerfilUsuario
    {
        [Display(Name = "Administrador")]
        Administrador = 1,

        [Display(Name = "Empresa de Transporte")]
        EmpresaDeTransporte = 2,

        [Display(Name = "Cliente Empresa")]
        ClienteEmpresa = 3,

        [Display(Name = "Governo")]
        Governo = 4,

        [Display(Name = "Funcionário")]
        Funcionario = 5

    }
}

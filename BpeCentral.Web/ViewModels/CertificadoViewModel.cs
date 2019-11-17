using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BpeCentral.Dominio.Comum.Enum;
using BpeCentral.Dominio;

namespace BpeCentral.Web.ViewModels
{
    public class CertificadoViewModel
    {
        [Display(Name = "Emitente")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int CODIGO_EMITENTE { get; set; }
        [Display(Name = "Senha")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string SENHA { get; set; }

        [Display(Name = "Data Final")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DATA_FINAL { get; set; }
    }
}
using BpeCentral.Dominio.Comum.Enums;
using BpeCentral.Web.Filters;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BpeCentral.Web.ViewModels
{
    public class BpesProcessadosXmlViewModel
    {
        [Required(ErrorMessage = "Preencha o campo Data")]
        [DisplayName("Data")]
        public string DataQuantidade { get; set; }
        [Required(ErrorMessage = "Preencha o campo Data")]
        
        public string DataConsultaXml { get; set; }

        [Required(ErrorMessage = "Preencha o campo Usuario")]
        [DisplayName("Usuário")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "Preencha o campo Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Preencha o campo Codigo Estado")]
        [DisplayName("Código do Estado")]
        public EstadoEnum? CodEstado { get; set; }
    }
}
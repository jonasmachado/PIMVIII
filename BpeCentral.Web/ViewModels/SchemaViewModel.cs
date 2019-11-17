using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using BpeCentral.Dominio.Comum.Enum;
using BpeCentral.Dominio;

namespace BpeCentral.Web.ViewModels
{
    public class SchemaViewModel
    {
        [Required(ErrorMessage = "Selecione um arquivo")]
        [Display(Name = "Arquivos:")]
        public HttpPostedFileBase[] files { get; set; }
    }
}
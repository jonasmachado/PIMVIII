using BpeCentral.Web.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace BpeCentral.Web.ViewModels
{
    public class VersaoDllServicoViewModel
    {
        public int Id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Preencha o campo Versão")]
        [Display(Name ="Versão")]
        public string Versao { get; set; }

        [Required(ErrorMessage = "Preencha o campo URL")]
        [Display(Name = "Endereço")]
        public string URL { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descricao")]
        [Display(Name = "Descrição")]   
        public string Descricao { get; set; }
    }
}
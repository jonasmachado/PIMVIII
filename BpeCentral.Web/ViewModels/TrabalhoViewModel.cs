
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HomeworkBuddy.Web.ViewModels
{
    public class TrabalhoViewModel
    {
        public int Id_Trabalho { get; set; }

        [Display(Name = "Matéria")]
        public string Materia { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Status")]
        public bool Entregue { get; set; }

        [Display(Name = "Data para Entrega")]
        public DateTime DataParaEntrega { get; set; }
    }
}
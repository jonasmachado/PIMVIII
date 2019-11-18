
using System;
using System.Collections.Generic;

namespace BpeCentral.Web.ViewModels
{
    public class TrabalhoViewModel
    {
        public int Id_Trabalho { get; set; }

        public string Materia { get; set; }

        public string Titulo { get; set; }

        public bool Entregue { get; set; }

        public DateTime DataParaEntrega { get; set; }
    }
}
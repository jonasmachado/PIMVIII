using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BpeCentral.Dominio.Comum.Enum;
using BpeCentral.Dominio;

namespace BpeCentral.Web.ViewModels
{
    public class ControleSerieViewModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Tipo de Aplicação")]
        public int CODIGO_TIPO { get; set; }
        [Display(Name = "Série Inicial")]
        public int SERIE_INICIAL { get; set; }
        [Display(Name = "Série Final")]
        public int SERIE_FINAL { get; set; }
        [Display(Name = "Série Atual")]
        public int SERIE_ATUAL { get; set; }
        [Display(Name = "Sub Série Inicial")]
        public int SUB_SERIE_INICIAL { get; set; }
        [Display(Name = "Sub Série Final")]
        public int SUB_SERIE_FINAL { get; set; }
        [Display(Name = "Sub Série Atual")]
        public int SUB_SERIE_ATUAL { get; set; }
        [Display(Name = "Emitente")]
        public int CODIGO_EMITENTE { get; set; }
        public bool COMPLETA { get; set; }

        public virtual BPE_CONFIGURACAO_EMITENTE BPE_CONFIGURACAO_EMITENTE { get; set; }
        public virtual BPE_TIPO_APLICACAO BPE_TIPO_APLICACAO { get; set; }
    }
}
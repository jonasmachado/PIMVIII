using System.ComponentModel.DataAnnotations;
using BpeCentral.Dominio;

namespace BpeCentral.Web.ViewModels
{
    public class SerieBilheteViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Tipo de Aplicação")]
        public int CODIGO_TIPO { get; set; }
        [Display(Name = "Série")]
        public int SERIE { get; set; }
        [Display(Name = "SubSérie")]
        public int SUB_SERIE { get; set; }
        [Display(Name = "Bilhete")]
        public int BILHETE { get; set; }
        [Display(Name = "Emitente")]
        public int CODIGO_EMITENTE { get; set; }
        [Display(Name = "Cliente")]
        public int CODIGO_CLIENTE { get; set; }
        public string IMEI { get; set; }
    
        public BPE_CLIENTE BPE_CLIENTE { get; set; }
        public BPE_CONFIGURACAO_EMITENTE BPE_CONFIGURACAO_EMITENTE { get; set; }
        public BPE_TIPO_APLICACAO BPE_TIPO_APLICACAO { get; set; }
    }
}
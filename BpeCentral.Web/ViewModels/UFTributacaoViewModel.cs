using BpeCentral.Web.Filters;
using System;
using System.ComponentModel.DataAnnotations;

namespace BpeCentral.Web.ViewModels
{
    public class UFTributacaoViewModel
    {
        public int ID { get; set; }
        public string UF { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal ALIQUOTA_INTERESTADUAL { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]

        public decimal ALIQUOTA_INTERMUNICIPAL { get; set; }
        public string  CLASSIFICACAO_TRIBUTARIA { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public DateTime DATA_INCLUSAO { get; set; }

        [DisplayFormat(NullDisplayText = "")]
        public DateTime? DATA_ALTERACAO { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using BpeCentral.Dominio;

namespace BpeCentral.Web.ViewModels
{
    public class ClienteViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Data")]
        public System.DateTime DATA { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Tipo Cliente")]
        public int TIPO_CLIENTE { get; set; }

        public string TIPO_CLIENTE_STR { get; set; }

        [Display(Name = "Código Empresa")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int? CODIGO_EMPRESA { get; set; }

        [Display(Name = "Código DAER")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int? CODIGO_RODOVIARIA { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome Fiscal")]
        public string NOME_FISCAL { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Razão Social")]
        public string RAZAO_SOCIAL { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Cód. Município")]
        public int CODIGO_MUNICIPIO { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int CEP { get; set; }

        [Display(Name = "Logradouro")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string LOGRADOURO { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Bairro")]
        public string BAIRRO { get; set; }

        [Display(Name = "Município")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string MUNICIPIO { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string UF { get; set; }

        [Display(Name = "Número")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int NUMERO { get; set; }

        [Display(Name = "Complemento")]
        public string COMPLEMENTO { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "Preencha um e-mail válido")]
        public string EMAIL { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string TELEFONE { get; set; }

        [Display(Name = "Descrição")]
        public string DESCRICAO { get; set; }

        [Display(Name = "Data Online")]
        public DateTime? DATA_ONLINE { get; set; }

        [Display(Name = "Quantidade Dll")]
        public int? QTD_DLL { get; set; }

        [Display(Name = "Versão Script")]
        public string VERSAO_SCRIPT { get; set; }

        [Display(Name = "Versão Dll")]
        public string VERSAO_DLL { get; set; }

        public virtual ICollection<BPE_LOG_CLIENTE> BPE_LOG_CLIENTE { get; set; }
        public virtual ICollection<BPE_SERIE_BILHETE> BPE_SERIE_BILHETE { get; set; }
    }
}
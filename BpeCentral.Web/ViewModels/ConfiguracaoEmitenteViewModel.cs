using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BpeCentral.Dominio.Comum.Enum;
using System.Collections.Generic;
using BpeCentral.Dominio;
using BpeCentral.Dominio.Comum.Enums;

namespace BpeCentral.Web.ViewModels
{
    public class ConfiguracaoEmitenteViewModel
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Código da Empresa")]
        public int CODIGO_EMPRESA { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CNPJ { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "CNAE Fiscal")]
        public int CNAE_FISCAL { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Codigo Regime Tributário")]
        public int CODIGO_REGIME_TRIBUTARIO { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "IE")]
        public string INSCRICAO_ESTADUAL { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "IE Sub Tributário")]
        public string INSCRICAO_ESTADUAL_SUB_TRIBUTARIO { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Inscrição Municipal")]
        public string INSCRICAO_MUNICIPAL { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Nome Fiscal")]
        public string NOME_FISCAL { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Razão Social")]
        public string RAZAO_SOCIAL { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Termo Aut. Serv. Regular")]
        public string TERMO_AUTORIZACAO_SERV_REGULAR { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int CEP { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Código Município")]
        public int CODIGO_MUNICIPIO { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Logradouro")]
        public string LOGRADOURO { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Bairro")]
        public string BAIRRO { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Município")]
        public string MUNICIPIO { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Número")]
        public string NUMERO { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Complemento")]
        public string COMPLEMENTO { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "E-Mail")]
        [EmailAddress(ErrorMessage = "Preencha um e-mail válido")]
        public string EMAIL { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Telefone")]
        public string TELEFONE { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string UF { get; set; }
        [Display(Name = "Informação Adicional")]
        public string INFORMACAO_ADICIONAL { get; set; }
        public bool ATIVO { get; set; }
        public DateTime? DATA_INCLUSAO { get; set; }
        public DateTime DATA_ALTERACAO { get; set; }
        public int? CODIGO_IBGE { get; set; }

        public virtual ICollection<BPE_BPES> BPE_BPES { get; set; }
        public virtual ICollection<BPE_CONTROLE_SERIE> BPE_CONTROLE_SERIE { get; set; }
        public virtual ICollection<BPE_SERIE_BILHETE> BPE_SERIE_BILHETE { get; set; }
    }


}
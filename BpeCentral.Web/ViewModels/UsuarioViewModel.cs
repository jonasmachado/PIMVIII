using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BpeCentral.Dominio.Comum.Enum;

namespace BpeCentral.Web.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int Id_Usuario { get; set; }

        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(80, ErrorMessage = "Máximo de {0} caracteres")]
        [DisplayName("Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo e-mail")]
        [MaxLength(80, ErrorMessage = "Máximo de {0} caracteres")]
        [EmailAddress(ErrorMessage ="Preencha um e-mail válido")]
        //[Remote("EmailJaCadastrado", "Usuarios", ErrorMessage = "E-mail já foi cadastrado.")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo senha")]
        [MaxLength(80, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(6, ErrorMessage = "Mínimo de {0} caracteres")]
        [DisplayName("Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Repita a senha")]
        [MaxLength(80, ErrorMessage = "Máximo de {0} caracteres")]
        [MinLength(6, ErrorMessage = "Mínimo de {0} caracteres")]
        [DisplayName("Repita a senha")]
        [Compare("Senha", ErrorMessage = "A senha e a confirmação da senha são diferentes")]
        public string RepitaSenha { get; set; }

        [DisplayName("Perfil")]
        public int Perfil { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de cadastro")]
        public DateTime DataCadastro { get; set; }

        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
    }
}
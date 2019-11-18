using System.ComponentModel.DataAnnotations;

namespace BpeCentral.Web.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(25, ErrorMessage = "O campo {0} deve ter no máximo 25 caracteres.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "Endereço de e-mail inválido.")]
        public string Email { get; set; }
    }
}
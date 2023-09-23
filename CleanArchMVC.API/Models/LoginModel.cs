using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.API.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O formato do email é inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória.")]
        [StringLength(20, ErrorMessage = "O {0} deve ter no mínimo {2} e no máximo {1} caracter.")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
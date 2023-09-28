using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.API.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "O Usuàrio é obrigatório")]
        [Display(Name = "Usuário")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatória")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Senha")]
        [Compare("Password", ErrorMessage = "A Senha não confere.")]
        public string ConfirmPassword { get; set; }
    }
}
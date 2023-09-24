using System.ComponentModel.DataAnnotations;
using CleanArchMVC.Domain.Enum;

namespace CleanArchMVC.Application.DTOs
{
    public class PeopleDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Tipo de Pessoa é obrigatório")]
        public KindPerson KindPerson { get; set; }

        [Required(ErrorMessage = "O Documento é obrigatório")]
        public string Document { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Name { get; set; }

        public string Nickname { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório")]
        public string Address { get; set; }

        [Required(ErrorMessage = "O Perfil é obrigatório")]
        public ProfileType ProfileType { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
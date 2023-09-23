using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Application.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Name { get; set; }

        public int PeopleId { get; set; }

        public People? People { get; set; }
    }
}
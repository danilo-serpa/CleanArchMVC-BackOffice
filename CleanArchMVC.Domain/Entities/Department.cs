using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Entities
{
    public class Department : Entity
    {
        public Department(string name, int peopleId)
        {
            ValidationDomain(name, peopleId);
        }

        public Department(int id, string name, int peopleId)
        {
            DomainExceptionValidation.When(id < 0, "O campo Id é inválido");
            Id = id;
            ValidationDomain(name, peopleId);
        }


        public string Name { get; private set; }

        public int PeopleId { get; private set; }
        public People People { get; private set; }


        private void ValidationDomain(string name, int peopleId)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O campo Nome do Departamento é obrigatório");
            Name = name;
            PeopleId = peopleId;
        }
    }
}
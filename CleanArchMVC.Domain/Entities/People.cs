using CleanArchMVC.Domain.Enum;
using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Entities
{
    public class People : Entity
    {
        public People(KindPerson kindPerson, string document, string name, string nickname, string address)
        {
            ValidationDomain(kindPerson, document, name, nickname, address);
        }

        public People(int id, KindPerson kindPerson, string document, string name, string nickname, string address)
        {
            DomainExceptionValidation.When(id < 0, "O campo Id é inválido");
            Id = id;
            ValidationDomain(kindPerson, document, name, nickname, address);
        }

        public KindPerson KindPerson { get; private set; }
        public string Document { get; private set; }
        public string Name { get; private set; }
        public string Nickname { get; private set; }
        public string Address { get; private set; }

        public ICollection<Department> Departments { get; set; }


        private void ValidationDomain(KindPerson kindPerson, string document, string name, string nickname, string address)
        {
            DomainExceptionValidation.When(kindPerson <= 0, "O campo Responsável é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O campo Nome é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(document), "O campo Documento é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O campo Endereço é obrigatório");

            KindPerson = kindPerson;
            Document = document;
            Name = name;
            Nickname = nickname;
            Address = address;
        }
    }
}
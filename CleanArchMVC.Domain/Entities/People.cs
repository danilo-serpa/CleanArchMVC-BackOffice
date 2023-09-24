using CleanArchMVC.Domain.Enum;
using CleanArchMVC.Domain.Validation;

namespace CleanArchMVC.Domain.Entities
{
    public class People : Entity
    {
        public People(KindPerson kindPerson, string document, string name, string nickname, string address, ProfileType profileType)
        {
            ValidationDomain(kindPerson, document, name, nickname, address, profileType);
        }

        public People(int id, KindPerson kindPerson, string document, string name, string nickname, string address, ProfileType profileType)
        {
            DomainExceptionValidation.When(id < 0, "O campo Id é inválido");
            Id = id;
            ValidationDomain(kindPerson, document, name, nickname, address, profileType);
        }

        public KindPerson KindPerson { get; private set; }
        public string Document { get; private set; }
        public string Name { get; private set; }
        public string Nickname { get; private set; }
        public string Address { get; private set; }
        public ProfileType ProfileType { get; private set; }

        public ICollection<Department> Departments { get; set; }


        private void ValidationDomain(KindPerson kindPerson, string document, string name, string nickname, string address, ProfileType profileType)
        {
            DomainExceptionValidation.When(kindPerson <= 0, "O campo Tipo de Pessoa é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(document), "O campo Documento é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "O campo Nome é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(address), "O campo Endereço é obrigatório");
            DomainExceptionValidation.When(profileType <= 0, "O campo Perfil é obrigatório");

            KindPerson = kindPerson;
            Document = document;
            Name = name;
            Nickname = nickname;
            Address = address;
            ProfileType = profileType;
        }
    }
}
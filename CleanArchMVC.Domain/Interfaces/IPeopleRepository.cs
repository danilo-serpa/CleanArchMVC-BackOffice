using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<People>> GetPeoples();
        Task<People> GetById(int? id);

        Task<People> Create(People people);
        Task<People> Update(People people);
        Task<People> Remove(People people);
    }
}
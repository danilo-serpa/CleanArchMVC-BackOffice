using CleanArchMVC.Application.DTOs;

namespace CleanArchMVC.Application.Interfaces
{
    public interface IPeopleService
    {
        Task<IEnumerable<PeopleDTO>> GetPeoples();
        Task<PeopleDTO> GetById(int? id);
        Task Add(PeopleDTO peopleDTO);
        Task Update(PeopleDTO peopleDTO);
        Task Remove(int? id);
    }
}
using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;

namespace CleanArchMVC.Application.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _peopleRepository;
        private readonly IMapper _mapper;

        public PeopleService(IPeopleRepository peopleRepository, IMapper mapper)
        {
            _peopleRepository = peopleRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PeopleDTO>> GetPeoples()
        {
            var peopleEntities = await _peopleRepository.GetPeoples();
            return _mapper.Map<IEnumerable<PeopleDTO>>(peopleEntities);
        }

        public async Task<IEnumerable<PeopleDTO>> GetCollaborator()
        {
            var peopleEntities = await _peopleRepository.GetCollaborator();
            return _mapper.Map<IEnumerable<PeopleDTO>>(peopleEntities);
        }

        public async Task<PeopleDTO> GetById(int? id)
        {
            var peopleEntity = await _peopleRepository.GetById(id);
            return _mapper.Map<PeopleDTO>(peopleEntity);
        }

        public async Task Add(PeopleDTO peopleDTO)
        {
            var peopleEntity = _mapper.Map<People>(peopleDTO);
            await _peopleRepository.Create(peopleEntity);
        }

        public async Task Update(PeopleDTO peopleDTO)
        {
            var peopleEntity = _mapper.Map<People>(peopleDTO);
            await _peopleRepository.Update(peopleEntity);
        }

        public async Task Remove(int? id)
        {
            var peopleEntity = _peopleRepository.GetById(id).Result;
            await _peopleRepository.Remove(peopleEntity);
        }
    }
}
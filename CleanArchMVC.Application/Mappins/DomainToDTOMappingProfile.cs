using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Application.Mappins
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<People, PeopleDTO>().ReverseMap();
            CreateMap<Department, DepartmentDTO>().ReverseMap();
        }
        
    }
}
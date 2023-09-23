using AutoMapper;
using CleanArchMVC.Application.DTOs;
using CleanArchMVC.Application.Interfaces;
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;

namespace CleanArchMVC.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDTO>> GetDepartments()
        {
            var departmentEntities = await _departmentRepository.GetDepartments();
            return _mapper.Map<IEnumerable<DepartmentDTO>>(departmentEntities);
        }

        public async Task<DepartmentDTO> GetById(int? id)
        {
            var departmentEntity = await _departmentRepository.GetById(id);
            return _mapper.Map<DepartmentDTO>(departmentEntity);
        }

        public async Task Add(DepartmentDTO departmentDTO)
        {
            var departmentEntity = _mapper.Map<Department>(departmentDTO);
            await _departmentRepository.Create(departmentEntity);
        }

        public async Task Update(DepartmentDTO departmentDTO)
        {
            var departmentEntity = _mapper.Map<Department>(departmentDTO);
            await _departmentRepository.Update(departmentEntity);
        }

        public async Task Remove(int? id)
        {
            var departmentEntity = _departmentRepository.GetById(id).Result;
            await _departmentRepository.Remove(departmentEntity);
        }
    }
}
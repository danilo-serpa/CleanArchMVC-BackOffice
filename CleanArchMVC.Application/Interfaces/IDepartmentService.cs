using CleanArchMVC.Application.DTOs;

namespace CleanArchMVC.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentDTO>> GetDepartments();
        Task<DepartmentDTO> GetById(int? id);
        Task Add(DepartmentDTO departmentDTO);
        Task Update(DepartmentDTO departmentDTO);
        Task Remove(int? id);
    }
}
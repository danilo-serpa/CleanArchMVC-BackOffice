using CleanArchMVC.Domain.Entities;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetById(int? id);

        Task<Department> Create(Department department);
        Task<Department> Update(Department department);
        Task<Department> Remove(Department department);
    }
}
using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMVC.Infra.Data.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Department> GetById(int? id)
        {
            return await _context.Departments.SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> Create(Department department)
        {
            _context.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> Update(Department department)
        {
            _context.Update(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> Remove(Department department)
        {
            _context.Remove(department);
            await _context.SaveChangesAsync();
            return department;
        }
    }
}
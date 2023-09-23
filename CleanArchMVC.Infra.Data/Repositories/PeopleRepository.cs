using CleanArchMVC.Domain.Entities;
using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMVC.Infra.Data.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly ApplicationDbContext _context;

        public PeopleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<People> GetById(int? id)
        {
            return await _context.Peoples.FindAsync(id);
        }

        public async Task<IEnumerable<People>> GetPeoples()
        {
            return await _context.Peoples.ToListAsync();
        }

        public async Task<People> Create(People people)
        {
            _context.Add(people);
            await _context.SaveChangesAsync();
            return people;
        }

        public async Task<People> Update(People people)
        {
            _context.Update(people);
            await _context.SaveChangesAsync();
            return people;
        }

        public async Task<People> Remove(People people)
        {
            _context.Remove(people);
            await _context.SaveChangesAsync();
            return people;
        }
    }
}
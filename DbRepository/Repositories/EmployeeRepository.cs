using Data.Models;
using DbRepository.Base;
using DbRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbRepository.Repositories
{
    public class EmployeeRepository : BaseRepository, IEmployeeRepository
    {
        public EmployeeRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
        {
            Context = ContextFactory.CreateDbContext(ConnectionString);
        }
        public async Task<IEnumerable<Employee>> GetAllAsync() => await Context.Employees.ToListAsync();

        public async Task<Employee?> GetByIdAsync(int id) => await Context.Employees.FirstOrDefaultAsync(c => c.Id == id);


        public async Task<Employee> CreateAsync(Employee entity)
        {
            if (await Context.Employees.AnyAsync(c => c.Id == entity.Id))
                throw new ArgumentException(Constants.EntityIdExistMessage);
            await Context.Employees.AddAsync(entity);
            return await GetByIdAsync(entity.Id);
        }
        public async Task<Employee> UpdateAsync(Employee entity)
        {
            if (await GetByIdAsync(entity.Id) is null) throw new ArgumentException(Constants.EntityNotExistMessage);
            Context.Employees.Update(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            if (company is null) throw new ArgumentException(Constants.EntityNotExistMessage);
            Context.Employees.Remove(company);
            return true;
        }

        public async Task SaveAsync() => await Context.SaveChangesAsync();
    }
}

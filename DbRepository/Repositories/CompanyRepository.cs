using Data.Models;
using DbRepository.Base;
using DbRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbRepository.Repositories
{

    public class CompanyRepository : BaseRepository, ICompanyRepository
    {

        public CompanyRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
        {
            Context = ContextFactory.CreateDbContext(connectionString);
        }

        public async Task<IEnumerable<Company>> GetAllAsync() => await Context.Companies.ToListAsync();

        public async Task<Company?> GetByIdAsync(int id) => await Context.Companies.FirstOrDefaultAsync(c => c.Id == id);


        public async Task<Company> CreateAsync(Company entity)
        {
            if (await Context.Companies.AnyAsync(c => c.Id == entity.Id))
                throw new ArgumentException(Constants.EntityIdExistMessage);
            await Context.Companies.AddAsync(entity);
            return await GetByIdAsync(entity.Id);
        }
        public async Task<Company> UpdateAsync(Company entity)
        {
            if (await GetByIdAsync(entity.Id) is null) throw new ArgumentException(Constants.EntityNotExistMessage);
            Context.Companies.Update(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            if (company is null) throw new ArgumentException(Constants.EntityNotExistMessage);
            Context.Companies.Remove(company);
            return true;
        }

        public async Task SaveAsync() => await Context.SaveChangesAsync();

        public async Task<IEnumerable<Company>> GetCompaniesBaseInfo()
        {
            var fields = new string[]
            {
                "CompanyName",
                "City",
                "State",
                "Phone"
            };
            return await Context.Companies.SelectMembers(fields).ToListAsync();
        }
    }


}

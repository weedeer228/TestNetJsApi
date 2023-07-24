using System.Reflection.Metadata.Ecma335;
using Data.Models;
using DbRepository.Base;
using DbRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbRepository.Repositories
{

    public class CompanyRepository : BaseRepository, ICompanyRepository
    {

        public CompanyRepository(IRepositoryContextFactory contextFactory) : base(contextFactory)
        {
            Context = ContextFactory.CreateDbContext();
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
        public async Task<Company?> UpdateAsync(Company entity)
        {
            if (await GetByIdAsync(entity.Id) is null) return null;
            Context.Companies.Update(entity);
            return await GetByIdAsync(entity.Id);
        }
        public async Task<Company?> UpdateAsync(SimplifiledCompany entity)
        {
            var companyFromDb = await GetByIdAsync(entity.Id);
            if (companyFromDb is null) return null;
            companyFromDb.City = await GetOrCreateCityByNameAsync(entity);
            companyFromDb.Name = entity.Name;
            companyFromDb.State = entity.State;
            Context.Companies.Update(companyFromDb);
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
                "Id",
                "Name",
                "City",
                "State",
                "Phone"
            };
            return await Context.Companies.Include(c => c.City).SelectMembers(fields).ToListAsync();
        }

        public async Task<Company?> GetCompanyFullInfoById(int id)
        {
            var res = await Context.Companies
                .Include(c => c.City)
                .Include(c => c.Notes)
                .Include(c => c.Employees)
                .Include(c => c.History).
                ThenInclude(o => o.City).FirstOrDefaultAsync(c => c.Id == id);
            return res;
        }

        private async Task<City> GetOrCreateCityByNameAsync(SimplifiledCompany company)
        {
            var cityName = company.City;
            var cityFromDb = await Context.Cities.FirstOrDefaultAsync(c => c.Name == cityName);
            if (cityFromDb is null)
            {
                var companyFromDb = Context.Companies.First(x => x.Id == company.Id);
                await Context.Cities.AddAsync(new() { Name = cityName, Companies = new List<Company>() { companyFromDb } });
                await SaveAsync();
                return await Context.Cities.FirstAsync(c => c.Name == cityName);
            }
            return cityFromDb;
        }
    }


}

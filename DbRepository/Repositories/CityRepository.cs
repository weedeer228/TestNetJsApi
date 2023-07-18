using Data.Models;
using DbRepository.Base;
using DbRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbRepository.Repositories
{
    internal class CityRepository : BaseRepository, ICityRepository
    {
        public CityRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory)
        {
            Context = ContextFactory.CreateDbContext(ConnectionString);
        }

        public async Task<IEnumerable<City>> GetAllAsync() => await Context.Cities.ToListAsync();

        public async Task<City?> GetByIdAsync(int id) => await Context.Cities.FirstOrDefaultAsync(c => c.Id == id);


        public async Task<City> CreateAsync(City entity)
        {
            if (await Context.Cities.AnyAsync(c => c.Id == entity.Id))
                throw new ArgumentException(Constants.EntityIdExistMessage);
            await Context.Cities.AddAsync(entity);
            return await GetByIdAsync(entity.Id);
        }
        public async Task<City> UpdateAsync(City entity)
        {
            if (await GetByIdAsync(entity.Id) is null) throw new ArgumentException(Constants.EntityNotExistMessage);
            Context.Cities.Update(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            if (company is null) throw new ArgumentException(Constants.EntityNotExistMessage);
            Context.Cities.Remove(company);
            return true;
        }

        public async Task SaveAsync() => await Context.SaveChangesAsync();
    }
}

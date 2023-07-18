

using Data.Models;
using DbRepository.Base;
using DbRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbRepository.Repositories
{
    public class OrderRepository : BaseRepository, IOrdersRepository
    {

        public OrderRepository(IRepositoryContextFactory contextFactory) : base(contextFactory)
        {
            Context = contextFactory.CreateDbContext();
        }
        public async Task<IEnumerable<Order>> GetAllAsync() => await Context.Orders.ToListAsync();

        public async Task<Order?> GetByIdAsync(int id) => await Context.Orders.FirstOrDefaultAsync(c => c.Id == id);


        public async Task<Order> CreateAsync(Order entity)
        {
            if (await Context.Orders.AnyAsync(c => c.Id == entity.Id))
                throw new ArgumentException(Constants.EntityIdExistMessage);

            await Context.Orders.AddAsync(entity);

            return await GetByIdAsync(entity.Id);
        }
        public async Task<Order> UpdateAsync(Order entity)
        {
            if (await GetByIdAsync(entity.Id) is null) throw new ArgumentException(Constants.EntityNotExistMessage);
            Context.Orders.Update(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            if (company is null) throw new ArgumentException(Constants.EntityNotExistMessage);
            Context.Orders.Remove(company);
            return true;
        }

        public async Task SaveAsync() => await Context.SaveChangesAsync();
    }
}


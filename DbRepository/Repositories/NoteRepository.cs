using Data.Models;
using DbRepository.Base;
using DbRepository.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbRepository.Repositories
{
    public class NoteRepository : BaseRepository, INoteRepository
    {
        public NoteRepository(IRepositoryContextFactory contextFactory) : base(
             contextFactory)
        {
            Context = ContextFactory.CreateDbContext();
        }

        public async Task<IEnumerable<Note>> GetAllAsync() => await Context.Notes.Include(n => n.Employee).ToListAsync();

        public async Task<Note?> GetByIdAsync(int id) =>
            await Context.Notes.FirstOrDefaultAsync(c => c.Id == id);


        public async Task<Note> CreateAsync(Note entity)
        {
            if (await Context.Notes.AnyAsync(c => c.Id == entity.Id))
                throw new ArgumentException(Constants.EntityIdExistMessage);
            await Context.Notes.AddAsync(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task<Note> UpdateAsync(Note entity)
        {
            if (await GetByIdAsync(entity.Id) is null) throw new ArgumentException(Constants.EntityNotExistMessage);
            Context.Notes.Update(entity);
            return await GetByIdAsync(entity.Id);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var company = await GetByIdAsync(id);
            if (company is null) throw new ArgumentException(Constants.EntityNotExistMessage);
            Context.Notes.Remove(company);
            return true;
        }

        public async Task SaveAsync() => await Context.SaveChangesAsync();
    }
}
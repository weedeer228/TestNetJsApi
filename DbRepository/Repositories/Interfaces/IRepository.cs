namespace DbRepository.Repositories.Interfaces
{
    /// <summary>
    /// для in memory базы правильнее будет сделать синхронные методы, но при изменении бд все равно придется менять методы на асинхронные;
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAllAsync();

        public Task<T?> GetByIdAsync(int id);
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity);
        public Task<bool> DeleteAsync(int id);

        public Task SaveAsync();


    }

}

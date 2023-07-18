using Microsoft.EntityFrameworkCore;

namespace DbRepository
{
    public class RepositoryContextFactory : IRepositoryContextFactory
    {
        public RepositoryContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseInMemoryDatabase("TestAssigmentDb");

            return new RepositoryContext(optionsBuilder.Options);
        }
    }

    public interface IRepositoryContextFactory
    {
        RepositoryContext CreateDbContext();
    }
}

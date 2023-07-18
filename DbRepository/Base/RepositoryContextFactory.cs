﻿using Microsoft.EntityFrameworkCore;

namespace DbRepository
{
    public class RepositoryContextFactory : IRepositoryContextFactory
    {
        public RepositoryContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseInMemoryDatabase(connectionString);

            return new RepositoryContext(optionsBuilder.Options);
        }
    }

    public interface IRepositoryContextFactory
    {
        RepositoryContext CreateDbContext(string connectionString);
    }
}

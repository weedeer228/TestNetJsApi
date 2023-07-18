namespace DbRepository.Base
{
    public abstract class BaseRepository
    {
        protected RepositoryContext Context;
        protected IRepositoryContextFactory ContextFactory { get; }
        public BaseRepository(IRepositoryContextFactory contextFactory)
        {

            ContextFactory = contextFactory;
        }
    }
}

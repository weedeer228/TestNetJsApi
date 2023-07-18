using Data.Models;

namespace DbRepository.Repositories.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        public Task<IEnumerable<Company>> GetCompaniesBaseInfo();
    }
}

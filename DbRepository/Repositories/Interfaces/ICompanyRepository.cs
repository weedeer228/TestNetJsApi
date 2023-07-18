using Data.Models;

namespace DbRepository.Repositories.Interfaces
{
    internal interface ICompanyRepository : IRepository<Company>
    {
        public Task<IEnumerable<Company>> GetCompaniesBaseInfo();
    }
}

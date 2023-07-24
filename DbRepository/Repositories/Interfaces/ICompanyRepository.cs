using Data.Models;

namespace DbRepository.Repositories.Interfaces
{
    public interface ICompanyRepository : IRepository<Company>
    {
        public Task<IEnumerable<Company>> GetCompaniesBaseInfo();
        public Task<Company> UpdateAsync(SimplifiledCompany entity);

        public Task<Company> GetCompanyFullInfoById(int id);
    }
}

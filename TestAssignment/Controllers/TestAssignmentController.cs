using Data.Models;
using DbRepository.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestAssignment.Repository;

namespace TestAssignment.Controllers
{
    [ApiController]
    [Route("api")]
    public class TestAssignmentController : Controller
    {
        private IGeneralRepository _repository;

        public TestAssignmentController(IGeneralRepository generalRepository)
        {
            _repository = generalRepository;
        }

        [Route("Companies")]
        [HttpGet]
        public async Task<IActionResult> GetAllCompanies()
        {
            var result = await _repository.CompanyRepository.GetCompaniesBaseInfo();
            return Ok(result);
        }

        [Route("Companies/id")]
        [HttpGet]
        public async Task<IActionResult> GetCompanyDetails([FromQuery] int id)
        {
            var result = await _repository.CompanyRepository.GetCompanyFullInfoById(id);
            if (result is null) return NotFound();
            return Ok(result);
        }
        [Route("Notes")]
        [HttpGet]
        public async Task<IActionResult> GetAllNotes()
        {
            var result = await _repository.NoteRepository.GetAllAsync();
            return Ok(result);
        }

        [Route("Employees")]
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _repository.EmployeeRepository.GetAllAsync();
            return Ok(result);
        }

        [Route("Cities")]
        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var result = await _repository.CityRepository.GetAllAsync();
            return Ok(result);
        }


        [Route("update/company")]
        [HttpPost]
        public async Task<IActionResult> UpdateCompany([FromBody] SimplifiledCompany company)
        {
            var updatedCompany = await (_repository.CompanyRepository).UpdateAsync(company);
            if (updatedCompany is null) return NotFound();
            return Ok(updatedCompany);
        }

        [Route("Create/Mock")]
        [HttpPost]
        public async Task<IActionResult> CreateMock()
        {
            await _repository.CreateMockData();
            return Ok(await _repository.CompanyRepository.GetAllAsync());
        }




    }
}

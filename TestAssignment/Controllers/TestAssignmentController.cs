using Data.Models;
using Microsoft.AspNetCore.Mvc;
using TestAssignment.Repository;

namespace TestAssignment.Controllers
{
    [ApiController]
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
            var result = await _repository.CompanyRepository.GetAllAsync();
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

        [Route("Create/Mock")]
        [HttpPost]
        public async Task<IActionResult> CreateMock()
        {
            await _repository.CreateMockData();
            return Ok(await _repository.CompanyRepository.GetAllAsync());
        }







    }
}

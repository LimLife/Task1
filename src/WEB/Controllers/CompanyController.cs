using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Entity.Common;

namespace WEB.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IRepository _repository;
        public CompanyController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("companybyid/{id:int}")]
        public async Task<Company?> CompanyById(int id)
        {
            return await _repository.GetCompany(id);
        }

        [HttpGet]
        [Route("companies")]
        public async Task<List<Company>?> AllCompanies()
        {
            return await _repository.GetAllCompanies();
        }

        [HttpGet]
        [Route("employeescompany/{id:int}")]
        public async Task<List<Employee>?> AllEmployeeByCompany(int id)
        {
            return await _repository.GetAllEmployeeCompany(id);
        }
        [HttpGet]
        [Route("employee/{id:int}")]
        public async Task<Employee?> EmployeeById(int id)
        {
            return await _repository.GetEmployeeById(id);
        }

        [HttpGet]
        [Route("orderemployee/{id:int}")]
        public async Task<List<OrderEmployee>?> OrderEmployeeByCompany(int id)
        {
            return await _repository.OrderEmployee(id);
        }
        [HttpGet]
        [Route("storedate/{id:int}")]
        public async Task<List<StoreOrder>?> StoreDateByCompany(int id)
        {
            return await _repository.StoreOrder(id);
        }
    }
}

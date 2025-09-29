using Microsoft.AspNetCore.Mvc;
using WebApiService.Models.Dto;
using WebApiService.Services.Employee;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;

        [HttpGet]
        public IEnumerable<EmployeesDto> GetEmp()
        {
            return _employeeService.GetAllEmp();
        }
    }
}

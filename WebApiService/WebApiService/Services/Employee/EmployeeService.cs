using WebApiService.Models.Dto;
using WebApiService.Repositories.Employee;

namespace WebApiService.Services.Employee
{
    public class EmployeeService(IEmployeeRepository repository) : IEmployeeService
    {
        private readonly IEmployeeRepository _repository = repository;

        public IEnumerable<EmployeesDto> GetAllEmp()
        {
            try
            {
                return _repository.GetAllEmployees();
            }
            catch (Exception e)
            {
                Console.WriteLine("GetAllEmp: {mensaje}", e.Message);
                return [];
            }
        }
    }
}

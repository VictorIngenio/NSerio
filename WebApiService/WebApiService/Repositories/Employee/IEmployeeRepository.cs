using WebApiService.Models.Dto;

namespace WebApiService.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeesDto> GetAllEmployees();
    }
}

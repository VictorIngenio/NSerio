using WebApiService.Models.Dto;

namespace WebApiService.Services.Employee
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeesDto> GetAllEmp();
    }
}

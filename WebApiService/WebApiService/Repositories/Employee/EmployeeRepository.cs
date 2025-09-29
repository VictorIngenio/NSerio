using WebApiService.Models.Context;
using WebApiService.Models.Dto;

namespace WebApiService.Repositories.Employee
{
    public class EmployeeRepository(StoreContext context) : IEmployeeRepository
    {
        private readonly StoreContext _context = context;

        public IEnumerable<EmployeesDto> GetAllEmployees()
        {
            try
            {
                List<EmployeesDto> lista = [];

                lista = (from resp in _context.Employees
                         select new EmployeesDto 
                         {
                             Empid = resp.empid,
                             FullName = resp.firstname + " " + resp.lastname
                         }).ToList();

                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("GetAllEmployees: {mensaje}", e.Message);
                return [];
            }
        }
    }
}

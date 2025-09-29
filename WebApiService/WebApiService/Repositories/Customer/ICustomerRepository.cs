using WebApiService.Models.Entities;

namespace WebApiService.Repositories.Customer
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetCustomers();

        IEnumerable<Customers> GetCustomer(string custName);
    }
}

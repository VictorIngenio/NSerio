using WebApiService.Models.Context;
using WebApiService.Models.Entities;

namespace WebApiService.Repositories.Customer
{
    public class CustomerRepository(StoreContext context) :ICustomerRepository
    {
        private readonly StoreContext _context = context;

        public IEnumerable<Customers> GetCustomer(string custName)
        {
            return (from resp in _context.Customers where resp.contactname.Contains(custName) select resp).ToList();
        }

        public IEnumerable<Customers> GetCustomers() 
        {
            return (from resp in _context.Customers select resp).ToList();
        }
    }
}

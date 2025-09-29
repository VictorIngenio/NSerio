using WebApiService.Models.Dto;
using WebApiService.Models.Entities;
using WebApiService.Repositories.Order;

namespace WebApiService.Services.Order
{
    public class OrderService(IOrderRepository repository) : IOrderService
    {
        private readonly IOrderRepository _repository = repository;

        public IEnumerable<SaleDatePredictionDto> GetSaleDatePredict()
        {
            try
            {
                return _repository.GetSaleDatePredictions();
            }
            catch (Exception e)
            {
                Console.WriteLine("GetSaleDatePredict: {mensaje}", e.Message);
                return [];
            }
        }

        public IEnumerable<SaleDatePredictionDto> GetSaleDatePredict(string custName)
        {
            try
            {
                return _repository.GetSaleDatePredictions(custName);
            }
            catch (Exception e)
            {
                Console.WriteLine("GetSaleDatePredictByCustName: {mensaje}", e.Message);
                return [];
            }
        }

        public void InsertOrd(OrderInsertDto order)
        {
            try
            {
                _repository.InsertOrder(order);
            }
            catch (Exception e)
            {
                Console.WriteLine("InsertOrd: {mensaje}", e.Message);
            }
        }

        public IEnumerable<OrdersDto> Orders(int custid)
        {
            try
            {
                return _repository.GetOrders(custid);
            }
            catch (Exception e)
            {
                Console.WriteLine("Orders: {mensaje}", e.Message);
                return [];
            }
        }
    }
}

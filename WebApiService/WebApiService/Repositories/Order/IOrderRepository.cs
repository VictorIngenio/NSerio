using WebApiService.Models.Dto;
using WebApiService.Models.Entities;

namespace WebApiService.Repositories.Order
{
    public interface IOrderRepository
    {
        IEnumerable<OrdersDto> GetOrders(int custid);

        void InsertOrder(OrderInsertDto order);

        IEnumerable<SaleDatePredictionDto> GetSaleDatePredictions();

        IEnumerable<SaleDatePredictionDto> GetSaleDatePredictions(string custName);
    }
}

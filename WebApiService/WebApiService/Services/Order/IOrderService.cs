using WebApiService.Models.Dto;
using WebApiService.Models.Entities;

namespace WebApiService.Services.Order
{
    public interface IOrderService
    {
        IEnumerable<OrdersDto> Orders(int custid);

        void InsertOrd(OrderInsertDto order);

        IEnumerable<SaleDatePredictionDto> GetSaleDatePredict();

        IEnumerable<SaleDatePredictionDto> GetSaleDatePredict(string custName);
    }
}

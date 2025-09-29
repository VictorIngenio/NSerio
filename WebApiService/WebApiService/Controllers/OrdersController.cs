using Microsoft.AspNetCore.Mvc;
using WebApiService.Models.Dto;
using WebApiService.Models.Entities;
using WebApiService.Services.Order;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        private readonly IOrderService _orderService = orderService;

        [HttpGet("GetOrdersByCustId")]
        public IEnumerable<OrdersDto> GetOrderByClId(int custid)
        {
            return _orderService.Orders(custid);
        }

        [HttpPost("InsertOrder")]
        public void Post([FromBody] OrderInsertDto order) 
        {
            _orderService.InsertOrd(order);
        }

        [HttpGet("GetPredictionOrders")]
        public IEnumerable<SaleDatePredictionDto> GetPredictionOrd()
        {
            return _orderService.GetSaleDatePredict();
        }

        [HttpGet("GetPredictionOrdersByCustName")]
        public IEnumerable<SaleDatePredictionDto> GetPredictionOrd(string custName)
        {
            return _orderService.GetSaleDatePredict(custName);
        }
    }
}

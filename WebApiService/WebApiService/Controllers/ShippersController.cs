using Microsoft.AspNetCore.Mvc;
using WebApiService.Models.Dto;
using WebApiService.Services.Shipper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippersController(IShipperService shipperService) : ControllerBase
    {
        private readonly IShipperService _shipperService = shipperService;

        [HttpGet]
        public IEnumerable<ShippersDto> GetShip()
        {
            return _shipperService.GetAllShip();
        }
    }
}

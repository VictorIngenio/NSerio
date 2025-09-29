using WebApiService.Models.Dto;

namespace WebApiService.Services.Shipper
{
    public interface IShipperService
    {
        IEnumerable<ShippersDto> GetAllShip();
    }
}

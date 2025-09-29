using WebApiService.Models.Dto;

namespace WebApiService.Repositories.Shipper
{
    public interface IShipperRepository
    {
        IEnumerable<ShippersDto> GetAllShippers();
    }
}

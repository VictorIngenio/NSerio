using WebApiService.Models.Dto;
using WebApiService.Repositories.Shipper;

namespace WebApiService.Services.Shipper
{
    public class ShipperService(IShipperRepository repository) : IShipperService
    {
        private readonly IShipperRepository _repository = repository;

        public IEnumerable<ShippersDto> GetAllShip()
        {
            try
            {
                return _repository.GetAllShippers();
            }
            catch (Exception e)
            {
                Console.WriteLine("GetAllShip: {mensaje}", e.Message);
                return [];
            }
        }
    }
}

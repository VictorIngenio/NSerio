using WebApiService.Models.Context;
using WebApiService.Models.Dto;

namespace WebApiService.Repositories.Shipper
{
    public class ShipperRepository(StoreContext context) : IShipperRepository
    {
        private readonly StoreContext _context = context;

        public IEnumerable<ShippersDto> GetAllShippers()
        {
            try
            {
                List<ShippersDto> lista = [];

                lista = (from resp in _context.Shippers
                         select new ShippersDto 
                         {
                             Shipperid = resp.shipperid,
                             Companyname = resp.companyname
                         }).ToList();

                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("GetAllShippers: {mensaje}", e.Message);
                return [];
            }
        }
    }
}

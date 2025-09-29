using WebApiService.Models.Context;
using WebApiService.Models.Dto;

namespace WebApiService.Repositories.Product
{
    public class ProductRepository(StoreContext context) : IProductRepository
    {
        private readonly StoreContext _context = context;

        public IEnumerable<ProductsDto> GetAllProducts()
        {
            try
            {
                List<ProductsDto> lista = [];

                lista = (from resp in _context.Products
                         select new ProductsDto 
                         {
                             Productid = resp.productid,
                             Productname = resp.productname
                         }).ToList();

                return lista;
            }
            catch (Exception e)
            {
                Console.WriteLine("GetAllProducts: {mensaje}", e.Message);
                return [];
            }
        }
    }
}

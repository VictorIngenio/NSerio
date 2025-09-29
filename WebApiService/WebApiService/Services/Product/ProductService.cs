using WebApiService.Models.Dto;
using WebApiService.Repositories.Product;

namespace WebApiService.Services.Product
{
    public class ProductService(IProductRepository repository) : IProductService
    {
        private readonly IProductRepository _repository = repository;

        public IEnumerable<ProductsDto> GetAllProd()
        {
            try
            {
                return _repository.GetAllProducts();
            }
            catch (Exception e)
            {
                Console.WriteLine("GetAllProd: {mensaje}", e.Message);
                return [];
            }
        }
    }
}

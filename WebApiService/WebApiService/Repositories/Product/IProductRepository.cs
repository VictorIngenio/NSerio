using WebApiService.Models.Dto;

namespace WebApiService.Repositories.Product
{
    public interface IProductRepository
    {
        IEnumerable<ProductsDto> GetAllProducts();
    }
}

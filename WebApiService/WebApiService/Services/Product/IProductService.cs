using WebApiService.Models.Dto;

namespace WebApiService.Services.Product
{
    public interface IProductService
    {
        IEnumerable<ProductsDto> GetAllProd();
    }
}

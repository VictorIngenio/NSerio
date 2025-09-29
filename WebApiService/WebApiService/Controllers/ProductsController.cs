using Microsoft.AspNetCore.Mvc;
using WebApiService.Models.Dto;
using WebApiService.Services.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet]
        public IEnumerable<ProductsDto> GetProd()
        {
            return _productService.GetAllProd();
        }
    }
}

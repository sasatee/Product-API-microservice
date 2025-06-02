using Core.ServiceContracts;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
           _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
          
            return Ok( await _productService.GetAllProductsAsync()); 
        }

        [HttpGet]
        [Route("{filter}")]
        public async Task<IActionResult> GetProductByCondition(string filter)
        {

            return Ok(await _productService.GetProductByConditionAsync(filter));

        }
    }
}

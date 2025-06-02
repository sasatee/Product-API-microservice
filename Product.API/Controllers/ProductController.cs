using Core.DTOs;
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
            return Ok(await _productService.GetAllProductsAsync());
        }

        [HttpGet]
        [Route("filter/{filter}")] 
        public async Task<IActionResult> GetProductByCondition(string filter)
        {
            return Ok(await _productService.GetProductByConditionAsync(filter));
        }

        [HttpGet]
        [Route("{id}")] 
        public async Task<IActionResult> GetProductById(Guid id)
        {
            return Ok(await _productService.GetProductbyIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductAddRequest productAddRequest)
        {
            if (productAddRequest == null) 
            {

                return BadRequest();
            }
            else
            {
                await _productService.CreateProductAsync(productAddRequest);
                return CreatedAtAction(nameof(CreateProduct), new {productAddRequest.Id},productAddRequest);
            }
        }
    }
}

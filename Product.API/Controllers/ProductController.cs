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
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductAddRequest productAddRequest)
        {
            if (productAddRequest == null)
            {

                return BadRequest();
            }
            else
            {
                var result =  await _productService.CreateProductAsync(productAddRequest);
                return CreatedAtAction(nameof(CreateProduct), new { result?.Id }, productAddRequest);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }

        [HttpGet("Filter")]
       
        public async Task<IActionResult> GetProductByCondition([FromQuery] string productName)
        {
            return Ok(await _productService.GetProductByConditionAsync(productName));
        }

        [HttpGet("{id}")]
    
        public async Task<IActionResult> GetProductById(Guid id)
        {
            return Ok(await _productService.GetProductbyIdAsync(id));
        }

        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateProductById(Guid id, ProductUpdateRequest? obj)
        {
            if (obj == null) return BadRequest();
            await _productService.UpdateProductAsync(id, obj);
            return NoContent();
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProductById(Guid id)
        {
           
             await _productService.DeleteProductAsync(id);
            return NoContent();
        }
      
    }
}

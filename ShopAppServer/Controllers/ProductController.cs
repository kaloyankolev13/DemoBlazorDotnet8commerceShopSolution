using Microsoft.AspNetCore.Mvc;
using PhoneShopSharedLibrary.Contract;
using PhoneShopSharedLibrary.Models;
using PhoneShopSharedLibrary.Responses;

namespace ShopAppServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _productRepository;
        public ProductController(IProduct productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProducts(bool featured)
        {
            var products = await _productRepository.GetAllProducts(featured); return Ok(products);
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddProduct(Product model)
        {
            if (model is null) return BadRequest("Model is null");
            var response = await _productRepository.AddProduct(model);
            return Ok(response);
        }
    }
}

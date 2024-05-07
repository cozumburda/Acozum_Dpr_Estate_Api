using Acozum_Dpr_Estate_Api.Repositories.ProductImageRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageRepository _productImageRepository;

        public ProductImagesController(IProductImageRepository productImageRepository)
        {
            _productImageRepository = productImageRepository;
        }

        [HttpGet("GetProductImageByProductId")]
        public async Task<IActionResult> GetProductImageByProductId(int id)
        {
            var value = await _productImageRepository.GetProductImagesProductIdAsync(id);
            return Ok(value);
        }
    }
}

using Acozum_Dpr_Estate_Api.Dtos.ProductDtos;
using Acozum_Dpr_Estate_Api.Repositories.ProductRepository;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productRepository.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            var values = await _productRepository.GetAllProductWithCategoryAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductWithCategoryDto createProductWithCategoryDto)
        {
            _productRepository.CreateProductWithCategory(createProductWithCategoryDto);
            return Ok("Veri Başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            _productRepository.DeleteProductWithCategory(id);
            return Ok("Veri Kısmı Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductWithCategoryDto updateProductWithCategoryDto)
        {
            _productRepository.UpdateProductWithCategory(updateProductWithCategoryDto);
            return Ok("Veri Başarılı Bir Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var value = await _productRepository.GetProductWithCategory(id);
            return Ok(value);
        }

        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
             _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Günün Fırsatları Arasına Eklendi");
        }

        [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Günün Fırsatları Arasından Çıkarıldı");
        }

        [HttpGet("Last5ProductList")]
        public async Task<IActionResult> Last5ProductList()
        {
            var values = await _productRepository.GetLast5ProductAsync();
            return Ok(values);
        }

        [HttpGet("ProductListLast5")]
        public async Task<IActionResult> ProductListLast5()
        {
            var values1 = await _productRepository.GetAllProductWithCategoryAsync();
            var list5 = values1.Where(x=>x.type=="Kiralık").OrderByDescending(x => x.productID);
            var top5 = list5.Take(5);
            return Ok(top5);
        }
    }
}

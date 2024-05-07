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
           await _productRepository.CreateProductWithCategory(createProductWithCategoryDto);
            return Ok("Veri Başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productRepository.DeleteProductWithCategory(id);
            return Ok("Veri Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductWithCategoryDto updateProductWithCategoryDto)
        {
           await _productRepository.UpdateProductWithCategory(updateProductWithCategoryDto);
            return Ok("Veri Başarılı Bir Şekilde Güncellendi");
        }
        [HttpGet("GetProduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var value = await _productRepository.GetProductByProductIdWithCategoryAsync(id);
            return Ok(value);
        }                

        [HttpGet("ProductDealOfTheDayStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            await _productRepository.ProductDealOfTheDayStatusChangeToTrue(id);
            return Ok("İlan Günün Fırsatları Arasına Eklendi");
        }

        [HttpGet("ProductDealOfTheDayStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductDealOfTheDayStatusChangeToFalse(int id)
        {
           await _productRepository.ProductDealOfTheDayStatusChangeToFalse(id);
            return Ok("İlan Günün Fırsatları Arasından Çıkarıldı");
        }
        [HttpGet("ProductStatusChangeToTrue/{id}")]
        public async Task<IActionResult> ProductStatusChangeToTrue(int id)
        {
            await _productRepository.ProductStatusChangeToTrue(id);
            return Ok("İlan Durumu Aktif Yapıldı");
        }
        [HttpGet("ProductStatusChangeToFalse/{id}")]
        public async Task<IActionResult> ProductStatusChangeToFalse(int id)
        {
            await _productRepository.ProductStatusChangeToFalse(id);
            return Ok("İlan Durumu Pasif Yapıldı");
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
            var list5 = values1.Where(x => x.type == "Kiralık").OrderByDescending(x => x.productID);
            var top5 = list5.Take(5);
            return Ok(top5);
        }
        [HttpGet("ProductAdvertsListByEmployeeByTrue")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByTrue(int id)
        {
            var values = await _productRepository.GetProductAdvertsListByEmployeeByTrueAsync(id);
            return Ok(values);
        }
        [HttpGet("ProductAdvertsListByEmployeeByFalse")]
        public async Task<IActionResult> ProductAdvertsListByEmployeeByFalse(int id)
        {
            var values = await _productRepository.GetProductAdvertsListByEmployeeByFalseAsync(id);
            return Ok(values);
        }
    }
}

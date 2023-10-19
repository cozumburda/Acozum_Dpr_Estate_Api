using Acozum_Dpr_Estate_Api.Dtos.CategoryDtos;
using Acozum_Dpr_Estate_Api.Repositories.CategoryRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryRepository.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryRepository.CreateCategory(createCategoryDto);
            return Ok("Kategori Başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _categoryRepository.DeleteCategory(id);
            return Ok("Kategori Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok("Kategori Başarılı Bir Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var value = await _categoryRepository.GetCategory(id);
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStatusCategory(int id, UpdateCategoryDto updateCategoryDto)
        {
            var value = await _categoryRepository.GetCategory(id);

            if (value.CategoryStatus == true)
            {
                value.CategoryStatus = false;
            }
            else if (value.CategoryStatus == false)
            {
                value.CategoryStatus = true;
            }
            updateCategoryDto.CategoryID = id;
            updateCategoryDto.CategoryName = value.CategoryName;
            updateCategoryDto.CategoryStatus = value.CategoryStatus;
            _categoryRepository.UpdateCategory(updateCategoryDto);
            return Ok("Durum Değiştirildi");
        }
    }
}

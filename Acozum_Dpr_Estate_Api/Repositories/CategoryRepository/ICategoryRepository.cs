using Acozum_Dpr_Estate_Api.Dtos.CategoryDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategory();
        Task<List<ResultCategoryIncludeProductsDto>> ResultCategoryIncludeProducts();
        Task CreateCategory(CreateCategoryDto createCategoryDto);
        Task DeleteCategory(int id);
        Task UpdateCategory(UpdateCategoryDto updateCategoryDto);
        Task<GetByIDCategoryDto> GetCategory(int id);
    }
}

using Acozum_Dpr_Estate_Api.Dtos.ProductDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        void CreateProductWithCategory(CreateProductWithCategoryDto createProductWithCategoryDto);
        void DeleteProductWithCategory(int id);
        void UpdateProductWithCategory(UpdateProductWithCategoryDto updateProductWithCategoryDto);
        Task<GetByIDProductWithCategoryDto> GetProductWithCategory(int id);
        void ProductDealOfTheDayStatusChangeToTrue(int id);
        void ProductDealOfTheDayStatusChangeToFalse(int id);
        Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync();
    }
}

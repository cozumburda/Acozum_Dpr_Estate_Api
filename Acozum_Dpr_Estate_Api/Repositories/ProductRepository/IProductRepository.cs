using Acozum_Dpr_Estate_Api.Dtos.ProductDetailDtos;
using Acozum_Dpr_Estate_Api.Dtos.ProductDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductAdvertsListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeByTrueAsync(int id);
        Task<List<ResultProductAdvertsListWithCategoryByEmployeeDto>> GetProductAdvertsListByEmployeeByFalseAsync(int id);
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task CreateProductWithCategory(CreateProductWithCategoryDto createProductWithCategoryDto);
        Task DeleteProductWithCategory(int id);
        Task UpdateProductWithCategory(UpdateProductWithCategoryDto updateProductWithCategoryDto);
        Task<GetByIDProductWithCategoryDto> GetProductByProductIdWithCategoryAsync(int id);
        Task<GetProductDetailByProductIdDto> GetProductDetailByProductIdWithCategoryAsync(int id);
        Task ProductDealOfTheDayStatusChangeToTrue(int id);
        Task ProductDealOfTheDayStatusChangeToFalse(int id);
        Task ProductStatusChangeToFalse(int id);
        Task ProductStatusChangeToTrue(int id);
        Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync();
        Task<List<ResultLast3ProductsWithCategoryAndEmployeeDto>> GetLast3ProductAsync();
        Task<List<ResultProductWithSearchListDto>> ResultProductWithSearchList(string? searchKeyValue,int? propertyCategoryId, string? city);
        Task<List<ResultProductCitiesDto>> ResultProductCities(int? propertyCategoryId);
    }
}

using Acozum_Dpr_Estate_Api.Dtos.ProductDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
    }
}

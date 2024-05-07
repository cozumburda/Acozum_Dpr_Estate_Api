using Acozum_Dpr_Estate_Api.Dtos.ProductDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories
{
    public interface ILast5ProductsRepository
    {
        Task<List<ResultProductWithCategoryDto>> GetLast5ProductAsync(int id);
    }
}

using Acozum_Dpr_Estate_Api.Dtos.ProductImageDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.ProductImageRepositories
{
    public interface IProductImageRepository
    {
        Task<List<GetProductImagesByProductIdDto>> GetProductImagesProductIdAsync(int id);
    }
}

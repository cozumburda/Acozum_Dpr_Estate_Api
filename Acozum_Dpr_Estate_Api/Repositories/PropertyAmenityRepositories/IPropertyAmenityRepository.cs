using Acozum_Dpr_Estate_Api.Dtos.PropertyAmenityDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.PropertyAmenityRepositories
{
    public interface IPropertyAmenityRepository
    {
        Task<List<ResultPropertyAmenityByStatusTrueDto>> ResultPropertyAmenityByStatusTrue(int id);
    }
}

using Acozum_Dpr_Estate_Api.Dtos.SubFeatureDtos;
using System.Threading.Tasks;

namespace Acozum_Dpr_Estate_Api.Repositories.SubFeatureRepositories
{
    public interface ISubFeatureRepository
    {
        Task<List<ResultSubFeatureDto>> GetAllSubFeatureAsync();
    }
}

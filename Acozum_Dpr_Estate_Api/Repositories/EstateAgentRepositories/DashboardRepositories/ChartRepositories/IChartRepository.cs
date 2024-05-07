using Acozum_Dpr_Estate_Api.Dtos.ChartDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.EstateAgentRepositories.DashboardRepositories.ChartRepositories
{
    public interface IChartRepository
    {
       Task<List<ResultChartDto>> Get5CityForChart();
    }
}

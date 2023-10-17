using Acozum_Dpr_Estate_Api.Dtos.BottomGridDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.BottomGridRepositories
{
    public interface IBottomGridRepository
    {
        Task<List<ResultBottomGridDto>> GetAllBottomGridAsync();
        void CreateBottomGrid(CreateBottomGridDto createBottomGridDto);
        void DeleteBottomGrid(int id);
        void UpdateBottomGrid(UpdateBottomGridDto updateBottomGridDto);
        Task<GetByIDBottomGridDto> GetBottomGrid(int id);
    }
}

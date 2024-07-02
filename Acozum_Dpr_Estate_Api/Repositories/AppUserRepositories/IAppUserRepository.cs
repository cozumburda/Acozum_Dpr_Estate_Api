using Acozum_Dpr_Estate_Api.Dtos.AppUserDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<List<ResultAppUserDto>> GetAllAppUserAsync();
        void CreateAppUser(CreateAppUserDto createAppUserDto);
        void DeleteAppUser(int id);
        void UpdateAppUser(UpdateAppUserDto updateAppUserDto);
        Task<GetByIdAppUserDto> GetAppUser(int id);
        Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id);
    }
}

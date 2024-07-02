using Acozum_Dpr_Estate_Api.Dtos.AppUserDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.AppUserRepositories
{
    public interface IAppUserRepository
    {
        Task<List<ResultAppUserDto>> GetAllAppUser();
        Task CreateAppUser(CreateAppUserDto createAppUserDto);
        Task DeleteAppUser(int id);
        Task UpdateAppUser(UpdateAppUserDto updateAppUserDto);
        Task<GetByIdAppUserDto> GetAppUser(int id);
        Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id);
    }
}

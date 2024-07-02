using Acozum_Dpr_Estate_Api.Dtos.AppUserDtos;
using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Dapper;

namespace Acozum_Dpr_Estate_Api.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public void CreateAppUser(CreateAppUserDto createAppUserDto)
        {
            throw new NotImplementedException();
        }

        public void DeleteAppUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultAppUserDto>> GetAllAppUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetByIdAppUserDto> GetAppUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<GetAppUserByProductIdDto> GetAppUserByProductId(int id)
        {
            string query = "Select * from AppUser Where UserId=@userId";
            var parameters = new DynamicParameters();
            parameters.Add("@userId", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetAppUserByProductIdDto>(query, parameters);
                return values;
            }
        }

        public void UpdateAppUser(UpdateAppUserDto updateAppUserDto)
        {
            throw new NotImplementedException();
        }
    }
}

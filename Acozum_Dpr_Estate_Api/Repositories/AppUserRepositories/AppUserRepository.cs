using Acozum_Dpr_Estate_Api.Dtos.AppUserDtos;
using Acozum_Dpr_Estate_Api.Dtos.LoginDtos;
using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Dapper;
using System.Net.NetworkInformation;

namespace Acozum_Dpr_Estate_Api.Repositories.AppUserRepositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly Context _context;

        public AppUserRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateAppUser(CreateAppUserDto createAppUserDto)
        {
            string query = "insert into AppUser(UserName,Password,Name,Email,UserRole,ImageUrl,PhoneNumber,Title,Status) values (@userName,@password,@name,@email,@userRole,@imageUrl,@phoneNumber,@title,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@userName", createAppUserDto.UserName);
            parameters.Add("@password", createAppUserDto.Password);
            parameters.Add("@name", createAppUserDto.Name);
            parameters.Add("@email", createAppUserDto.Email);
            parameters.Add("@userRole", createAppUserDto.UserRole);
            parameters.Add("@imageUrl", createAppUserDto.ImageUrl);
            parameters.Add("@phoneNumber", createAppUserDto.PhoneNumber);
            parameters.Add("@title", createAppUserDto.Title);
            parameters.Add("@Status", false);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async Task DeleteAppUser(int id)
        {
            string query = "Delete from AppUser Where UserId=@userId";
            var parameters = new DynamicParameters();
            parameters.Add("@userId", id);
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultAppUserDto>> GetAllAppUser()
        {
            string query = "Select * from AppUser";
            
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryAsync<ResultAppUserDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIdAppUserDto> GetAppUser(int id)
        {
            string query = "Select * from AppUser Where UserId=@userId";
            var parameters = new DynamicParameters();
            parameters.Add("@userId", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetByIdAppUserDto>(query, parameters);
                return values;
            }
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

        public async Task UpdateAppUser(UpdateAppUserDto updateAppUserDto)
        {
            string query = "Update AppUser set UserName=@userName,Password=@password,Name=@name,Email=@email,UserRole=@userRole,ImageUrl=@imageUrl,PhoneNumber=@phoneNumber,Title=@title,Status=@status Where UserId=@userId";
            var parameters = new DynamicParameters();
            parameters.Add("@userName", updateAppUserDto.UserName);
            parameters.Add("@password", updateAppUserDto.Password);
            parameters.Add("@name", updateAppUserDto.Name);
            parameters.Add("@email", updateAppUserDto.Email);
            parameters.Add("@userRole", updateAppUserDto.UserRole);
            parameters.Add("@imageUrl", updateAppUserDto.ImageUrl);
            parameters.Add("@phoneNumber", updateAppUserDto.PhoneNumber);
            parameters.Add("@title", updateAppUserDto.Title);
            parameters.Add("@Status", updateAppUserDto.Status);
            parameters.Add("@userId", updateAppUserDto.UserID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }
    }
}

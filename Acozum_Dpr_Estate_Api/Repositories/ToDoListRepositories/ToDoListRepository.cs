using Acozum_Dpr_Estate_Api.Dtos.ToDoListDtos;
using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Dapper;

namespace Acozum_Dpr_Estate_Api.Repositories.ToDoListRepositories
{
    public class ToDoListRepository : IToDoListRepository
    {
        private readonly Context _context;

        public ToDoListRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            string query = "insert into ToDoList(Description,Status) values (@description,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@description", createToDoListDto.Description);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async Task DeleteToDoList(int id)
        {
            string query = "Delete from ToDoList Where ToDoListID=@toDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@toDoListID", id);
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultToDoListDto>> GetAllToDoList()
        {
            string query = "Select * from ToDoList";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultToDoListDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDToDoListDto> GetToDoList(int id)
        {
            string query = "Select * from ToDoList Where ToDoListID=@toDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@toDoListID", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetByIDToDoListDto>(query, parameters);
                return values;
            }
        }

        public async Task UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            string query = "Update ToDoList set Description=@description, Status=@status Where ToDoListID=@toDoListID";
            var parameters = new DynamicParameters();
            parameters.Add("@description", updateToDoListDto.Description);
            parameters.Add("@status", updateToDoListDto.ToDoListStatus);
            parameters.Add("@toDoListID", updateToDoListDto.ToDoListID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }
    }
}

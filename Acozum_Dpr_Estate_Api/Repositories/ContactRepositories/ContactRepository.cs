using Acozum_Dpr_Estate_Api.Dtos.ContactDto;
using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Dapper;

namespace Acozum_Dpr_Estate_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateContact(CreateContactDto createContactDto)
        {
            string query = "insert into Contact(Name,Subject,Email,Message,SendDate,Status) values (@name,@subject,@email,@message,@sendDate,@status)";
            var parameters = new DynamicParameters();
            parameters.Add("@name", createContactDto.Name);
            parameters.Add("@subject", createContactDto.Subject);
            parameters.Add("@email", createContactDto.Email);
            parameters.Add("@message", createContactDto.Message);
            parameters.Add("@sendDate", createContactDto.SendDate);
            parameters.Add("@status", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }

        public async Task DeleteContact(int id)
        {
            string query = "Delete from Contact Where ContactID=@contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@contactID", id);
            using (var connections = _context.CreateConnection())
            {
                await connections.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            string query = "Select * from Contact";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public async Task<GetByIDContactDto> GetContact(int id)
        {
            string query = "Select * from Contact Where ContactID=@contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@contactID", id);
            using (var connections = _context.CreateConnection())
            {
                var values = await connections.QueryFirstOrDefaultAsync<GetByIDContactDto>(query, parameters);
                return values;
            }
        }

        public async Task<List<Last4ContactResultDto>> GetLast4ContactAsync()
        {
            string query = "select top(4) * from Contact order by ContactID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Last4ContactResultDto>(query);
                return values.ToList();
            }
        }

        public async Task UpdateContact(UpdateContactDto updateContactDto)
        {
            string query = "Update Contact set Name=@name, Subject=@subject, Email=@subject, Message=@message, SendDate=@sendDate, Status=@status Where ContactID=@contactID";
            var parameters = new DynamicParameters();
            parameters.Add("@name", updateContactDto.Name);
            parameters.Add("@subject", updateContactDto.Subject);
            parameters.Add("@email", updateContactDto.Email);
            parameters.Add("@message", updateContactDto.Message);
            parameters.Add("@sendDate", updateContactDto.SendDate);
            parameters.Add("@status", updateContactDto.Status);
            parameters.Add("@contactID", updateContactDto.ContactID);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            };
        }
    }
}

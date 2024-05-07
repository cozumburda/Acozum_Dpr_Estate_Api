using Acozum_Dpr_Estate_Api.Dtos.MessageDtos;
using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Dapper;

namespace Acozum_Dpr_Estate_Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxBoxLast3MessageListByReceiver(int id)
        {
            //string query = "select top(3) * from Message where Receiver=@receiverID order by MessageID desc";
            string query = "select top(3) MessageID,Subject,Detail,SendDate,IsRead,Receiver, ImageUrl, Name as SenderName from Message inner join AppUser on Message.Sender=AppUser.UserId where Receiver=@receiverID order by MessageID desc";
            var parameters = new DynamicParameters();
            parameters.Add("@receiverID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInboxMessageDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}

using Acozum_Dpr_Estate_Api.Dtos.MessageDtos;

namespace Acozum_Dpr_Estate_Api.Repositories.MessageRepositories
{
    public interface IMessageRepository
    {
        Task<List<ResultInboxMessageDto>> GetInboxBoxLast3MessageListByReceiver(int id);
    }
}

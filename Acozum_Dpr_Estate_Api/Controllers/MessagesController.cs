using Acozum_Dpr_Estate_Api.Repositories.MessageRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;

        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetInboxBoxLast3MessageListByReceiver(int id)
        {
            var values = await _messageRepository.GetInboxBoxLast3MessageListByReceiver(id);
            return Ok(values);
        }
    }
}

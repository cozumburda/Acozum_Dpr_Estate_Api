using Acozum_Dpr_Estate_Api.Repositories.ContactRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        [HttpGet("GetLast4ContactAsync")]
        public async Task<IActionResult> GetLast4ContactAsync()
        {
            var values = await _contactRepository.GetLast4ContactAsync();
            return Ok(values);
        }
    }
}

using Acozum_Dpr_Estate_Api.Repositories.PopularLocationRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PopularLocationsController : ControllerBase
    {
        private readonly IPopularLocationRepository _ipopularLocationRepository;

        public PopularLocationsController(IPopularLocationRepository ipopularLocationRepository)
        {
            _ipopularLocationRepository = ipopularLocationRepository;
        }
        [HttpGet]
        public async Task<IActionResult> PopularLocationList()
        {
            var value=await _ipopularLocationRepository.GetAllPopularLocationAsync();
            return Ok(value);
        }
    }
}

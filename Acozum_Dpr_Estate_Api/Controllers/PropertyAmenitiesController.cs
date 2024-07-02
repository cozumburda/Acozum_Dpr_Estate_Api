using Acozum_Dpr_Estate_Api.Repositories.PropertyAmenityRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyAmenitiesController : ControllerBase
    {
        private readonly IPropertyAmenityRepository _propertyAmenityRepository;

        public PropertyAmenitiesController(IPropertyAmenityRepository propertyAmenityRepository)
        {
            _propertyAmenityRepository = propertyAmenityRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> ResultPropertyAmenityByStatusTrue(int id)
        {
            var value = await _propertyAmenityRepository.ResultPropertyAmenityByStatusTrue(id);
            return Ok(value);
        }
    }
}

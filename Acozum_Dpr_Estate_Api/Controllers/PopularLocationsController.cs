using Acozum_Dpr_Estate_Api.Dtos.PopularLocationDtos;
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

        [HttpPost]
        public async Task<IActionResult> CreatePopularLocation(CreatePopularLocationDto createPopularLocationDto)
        {
            _ipopularLocationRepository.CreatePopularLocation(createPopularLocationDto);
            return Ok("Popüler Lokasyonlar Başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePopularLocation(int id)
        {
            _ipopularLocationRepository.DeletePopularLocation(id);
            return Ok("Popüler Lokasyonlar Kısmı Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePopularLocation(UpdatePopularLocationDto updatePopularLocationDto)
        {
            _ipopularLocationRepository.UpdatePopularLocation(updatePopularLocationDto);
            return Ok("Popüler Lokasyonlar Başarılı Bir Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPopularLocation(int id)
        {
            var value = await _ipopularLocationRepository.GetPopularLocation(id);
            return Ok(value);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> ChangeStatusPopularLocation(int id, UpdatePopularLocationDto updatePopularLocationDto)
        //{
        //    var value = await _ipopularLocationRepository.GetPopularLocation(id);

        //    if (value.PopularLocationStatus == true)
        //    {
        //        value.PopularLocationStatus = false;
        //    }
        //    else if (value.PopularLocationStatus == false)
        //    {
        //        value.PopularLocationStatus = true;
        //    }
        //    updatePopularLocationDto.PopularLocationID = id;
        //    updatePopularLocationDto.PopularLocationName = value.PopularLocationName;
        //    updatePopularLocationDto.PopularLocationStatus = value.PopularLocationStatus;
        //    _ipopularLocationRepository.UpdatePopularLocation(updatePopularLocationDto);
        //    return Ok("Hizmet Durumu Değiştirildi");
        //}
    }
}

using Acozum_Dpr_Estate_Api.Dtos.ServiceDtos;
using Acozum_Dpr_Estate_Api.Repositories.ServiceRepository;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServiceRepository _serviceRepository;
        public ServicesController(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetServiceList()
        {
            var value = await _serviceRepository.GetAllServiceAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto createServiceDto)
        {
            _serviceRepository.CreateService(createServiceDto);
            return Ok("Hakkımızda Kısmı Başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            _serviceRepository.DeleteService(id);
            return Ok("Hakkımızda Kısmı Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto updateServiceDto)
        {
            _serviceRepository.UpdateService(updateServiceDto);
            return Ok("Hakkımızda Kısmı Başarılı Bir Şekilde Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetService(int id)
        {
            var value = await _serviceRepository.GetService(id);
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStatusService(int id, UpdateServiceDto updateServiceDto)
        {
            var value = await _serviceRepository.GetService(id);

            if (value.ServiceStatus == true)
            {
                value.ServiceStatus = false;
            }
            else if (value.ServiceStatus == false)
            {
                value.ServiceStatus = true;
            }
            updateServiceDto.ServiceID = id;
            updateServiceDto.ServiceName = value.ServiceName;
            updateServiceDto.ServiceStatus = value.ServiceStatus;
            _serviceRepository.UpdateService(updateServiceDto);
            return Ok("Hizmet Durumu Değiştirildi");
        }
    }
}

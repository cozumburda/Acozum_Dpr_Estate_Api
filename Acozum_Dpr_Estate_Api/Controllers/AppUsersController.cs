using Acozum_Dpr_Estate_Api.Dtos.AppUserDtos;
using Acozum_Dpr_Estate_Api.Repositories.AppUserRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly IAppUserRepository _appUserRepository;

        public AppUsersController(IAppUserRepository appUserRepository)
        {
            _appUserRepository = appUserRepository;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppUserByProductId(int id) 
        {
            var value = await _appUserRepository.GetAppUserByProductId(id);
            return Ok(value);
        }

        [HttpGet("GetAllAppUser")]
        public async Task<IActionResult> GetAllAppUser()
        {
            var value = await _appUserRepository.GetAllAppUser();
            return Ok(value);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAppUser(CreateAppUserDto createAppUserDto)
        {
            await _appUserRepository.CreateAppUser(createAppUserDto);
            return Ok("Kullanıcı Başarılı bir şekilde eklendi.");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppUser(int id)
        {
            await _appUserRepository.DeleteAppUser(id);
            return Ok("Kullanıcı silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppUser(UpdateAppUserDto updateAppUserDto)
        {
            await _appUserRepository.UpdateAppUser(updateAppUserDto);
            return Ok("Kullanıcı Başarılı Bir Şekilde Güncellendi");
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetAppUser(int id)
        //{
        //    var value = await _appUserRepository.GetAppUser(id);
        //    return Ok(value);
        //}

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStatusCategory(int id, UpdateAppUserDto updateAppUserDto)
        {
            var value = await _appUserRepository.GetAppUser(id);

            if (value.Status == true)
            {
                value.Status = false;
            }
            else if (value.Status == false)
            {
                value.Status = true;
            }
            updateAppUserDto.UserID = id;
            updateAppUserDto.UserName = value.UserName;
            updateAppUserDto.Name = value.Name;
            updateAppUserDto.Password = value.Password;
            updateAppUserDto.Email = value.Email;
            updateAppUserDto.PhoneNumber = value.PhoneNumber;
            updateAppUserDto.UserRole = value.UserRole;
            updateAppUserDto.ImageUrl = value.ImageUrl;
            updateAppUserDto.Title = value.Title;
            updateAppUserDto.Status = value.Status;
            await _appUserRepository.UpdateAppUser(updateAppUserDto);
            return Ok("Durum Değiştirildi");
        }
    }
}

using Acozum_Dpr_Estate_Api.Dtos.EmployeeDtos;
using Acozum_Dpr_Estate_Api.Repositories.EmployeeRepositories;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var values = await _employeeRepository.GetAllEmployeeAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            _employeeRepository.CreateEmployee(createEmployeeDto);
            return Ok("Personel Başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return Ok("Personel Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            _employeeRepository.UpdateEmployee(updateEmployeeDto);
            return Ok("Personel Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var value = await _employeeRepository.GetEmployee(id);
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStatusEmployee(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            var value = await _employeeRepository.GetEmployee(id);

            if (value.Status == true)
            {
                value.Status = false;
            }
            else if (value.Status == false)
            {
                value.Status = true;
            }
            updateEmployeeDto.EmployeeID = id;
            updateEmployeeDto.Name = value.Name;
            updateEmployeeDto.Title = value.Title;
            updateEmployeeDto.Mail = value.Mail;
            updateEmployeeDto.PhoneNumber = value.PhoneNumber;
            updateEmployeeDto.ImageUrl = value.ImageUrl;
            updateEmployeeDto.Status = value.Status;
            _employeeRepository.UpdateEmployee(updateEmployeeDto);
            return Ok("Personel Durumu Değiştirildi");
        }
    }
}

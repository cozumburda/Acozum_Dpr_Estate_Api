using Acozum_Dpr_Estate_Api.Dtos.ToDoListDtos;
using Acozum_Dpr_Estate_Api.Repositories.ToDoListRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        private readonly IToDoListRepository _toDoListRepository;

        public ToDoListController(IToDoListRepository toDoListRepository)
        {
            _toDoListRepository = toDoListRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ToDoListList()
        {
            var values = await _toDoListRepository.GetAllToDoListAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            _toDoListRepository.CreateToDoListAsync(createToDoListDto);
            return Ok("Personel Başarılı bir şekilde eklendi.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            _toDoListRepository.DeleteToDoList(id);
            return Ok("Personel Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            _toDoListRepository.UpdateToDoList(updateToDoListDto);
            return Ok("Personel Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetToDoList(int id)
        {
            var value = await _toDoListRepository.GetToDoList(id);
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ChangeStatusToDoList(int id, UpdateToDoListDto updateToDoListDto)
        {
            var value = await _toDoListRepository.GetToDoList(id);

            if (value.ToDoListStatus == true)
            {
                value.ToDoListStatus = false;
            }
            else if (value.ToDoListStatus == false)
            {
                value.ToDoListStatus = true;
            }
            updateToDoListDto.ToDoListID = id;
            updateToDoListDto.Description = value.Description;
            updateToDoListDto.ToDoListStatus = value.ToDoListStatus;
            _toDoListRepository.UpdateToDoList(updateToDoListDto);
            return Ok("Personel Durumu Değiştirildi");
        }
    }
}

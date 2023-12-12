using Acozum_Dpr_Estate_UI.Dtos.ToDoListDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Acozum_Dpr_Estate_UI.Controllers
{
    public class ToDoListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ToDoListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44371/api/ToDoList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultToDoListDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateToDoList()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateToDoList(CreateToDoListDto createToDoListDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createToDoListDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44371/api/ToDoList", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Kategori Eklenmedi");
        }
        public async Task<IActionResult> DeleteToDoList(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44371/api/ToDoList/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Kategori Silinmedi");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateToDoList(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44371/api/ToDoList/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateToDoListDto>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateToDoList(UpdateToDoListDto updateToDoListDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateToDoListDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:44371/api/ToDoList", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Kategori Güncellenmedi");
        }
        public async Task<IActionResult> ChangeStatusToDoList(int id, UpdateToDoListDto updateToDoListDto)
        {
            updateToDoListDto.ToDoListID = 0;
            updateToDoListDto.Description = "string";
            updateToDoListDto.ToDoListStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateToDoListDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:44371/api/ToDoList/{id}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Durum Değiştirilemedi_1!");
        }
    }
}

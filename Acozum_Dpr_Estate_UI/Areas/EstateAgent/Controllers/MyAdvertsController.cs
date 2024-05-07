using Acozum_Dpr_Estate_UI.Dtos.CategoryDtos;
using Acozum_Dpr_Estate_UI.Dtos.ProductDtos;
using Acozum_Dpr_Estate_UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace Acozum_Dpr_Estate_UI.Areas.EstateAgent.Controllers
{

    [Area("EstateAgent")]
    //[Route("[area]/[controller]/[action]")]
    public class MyAdvertsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;

        public MyAdvertsController(IHttpClientFactory httpClientFactory, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
        }
        public async Task<IActionResult> ActiveAdverts()
        {
            int id = int.Parse(_loginService.GetUserId);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44371/api/Products/ProductAdvertsListByEmployeeByTrue?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertsListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> PassiveAdverts()
        {
            int id = int.Parse(_loginService.GetUserId);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44371/api/Products/ProductAdvertsListByEmployeeByFalse?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductAdvertsListWithCategoryByEmployeeDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> ProductStatusChangeToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44371/api/Products/ProductStatusChangeToTrue/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var url = "/EstateAgent/MyAdverts/ActiveAdverts/";
                return Redirect(url);
                //return RedirectToAction("ActiveAdverts", "MyAdverts", new { area = "EstateAgent" });
            }
            return View("Durum Değiştirilemedi_1!");
        }
        public async Task<IActionResult> ProductStatusChangeToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44371/api/Products/ProductStatusChangeToFalse/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var url = "/EstateAgent/MyAdverts/ActiveAdverts/";
                return Redirect(url);
                //return RedirectToAction("ActiveAdverts", "MyAdverts", new { area = "EstateAgent" });
            }
            return View("Durum Değiştirilemedi_1!");
        }
        [HttpGet]
        public async Task<IActionResult> CreateAdvert()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44371/api/Categories");

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categoryValues = (from x in values.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Value = x.CategoryID.ToString(),
                                                       Text = x.CategoryName
                                                   }).ToList();
            ViewBag.v = categoryValues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdvert(CreateProductDto createProductDto)
        {
            int userId = int.Parse(_loginService.GetUserId);
            createProductDto.EmployeeID = userId;
            createProductDto.DealOfTheDay = false;
            createProductDto.AdvertisementDate = DateTime.Now;
            createProductDto.ProductStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:44371/api/Products", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                var url = "/EstateAgent/MyAdverts/ActiveAdverts/";
                return Redirect(url);
            }
            return View("İlan Eklenmedi");
        }
    }
}

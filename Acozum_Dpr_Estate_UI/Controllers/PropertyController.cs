using Acozum_Dpr_Estate_UI.Dtos.ProductDetailDtos;
using Acozum_Dpr_Estate_UI.Dtos.ProductDtos;
using Acozum_Dpr_Estate_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Acozum_Dpr_Estate_UI.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public PropertyController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        //https://localhost:44371/api/
        public async Task<IActionResult> Index(string? searchKeyValue, int? propertyCategoryId, string? city)
        {
            if (propertyCategoryId == null) { propertyCategoryId = 0; }
            string sKValue = "";
            if (!string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId != 0 & !string.IsNullOrEmpty(city)) { sKValue = "?searchKeyValue=" + searchKeyValue + "&propertyCategoryId=" + propertyCategoryId + "&city=" + city; }
            else if (!string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId != 0 & string.IsNullOrEmpty(city)) { sKValue = "?searchKeyValue=" + searchKeyValue + "&propertyCategoryId=" + propertyCategoryId; }
            else if (!string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId == 0 & !string.IsNullOrEmpty(city)) { sKValue = "?searchKeyValue=" + searchKeyValue + "&city=" + city; }
            else if (!string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId == 0 & string.IsNullOrEmpty(city)) { sKValue = "?searchKeyValue=" + searchKeyValue; }
            else if (string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId != 0 & !string.IsNullOrEmpty(city)) { sKValue = "?propertyCategoryId=" + propertyCategoryId + "&city=" + city; }
            else if (string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId != 0 & string.IsNullOrEmpty(city)) { sKValue = "?propertyCategoryId=" + propertyCategoryId; }
            else if (string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId == 0 & !string.IsNullOrEmpty(city)) { sKValue = "?city=" + city; }
            else if (string.IsNullOrEmpty(searchKeyValue) & propertyCategoryId == 0 & string.IsNullOrEmpty(city)) { sKValue = ""; }

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Products/ResultProductWithSearchList" + sKValue);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductWithSearchListDto>>(jsonData);

                return View(values);
            }
            return View();
        }

        [HttpGet("property/GetCityList/{id}")]
        public IActionResult GetCityList(int? id)
        {
            return ViewComponent("_DefaultFeatureCitiesComponentPartial", new { id = id });
        }

        [HttpGet("property/{slug}/{id}")]
        public async Task<IActionResult> PropertySingle(string slug, int id)
        {
            //var id = 1;
            //ViewData["pId"] = id.ToString();
            ViewBag.pId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "ProductDetails/GetProductDetailByProductId?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetProductDetailByProductIdDto>(jsonData);
                if (values != null) { ViewBag.t = values.ProductTitle; }
                
                return View(values);
            }
            return View();
        }
        
    }
}

using Acozum_Dpr_Estate_UI.Dtos.ProductDtos;
using Acozum_Dpr_Estate_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Acozum_Dpr_Estate_UI.ViewComponents.HomePage
{
    public class _DefaultFeatureCitiesComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _DefaultFeatureCitiesComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync(int? id)
        {
            string idv = "";
            if (id != null) { idv = "?propertyCategoryId=" + id; }
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl+"Products/ResultProductCities" + idv);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var citvalues = JsonConvert.DeserializeObject<List<ResultProductCitiesDto>>(jsonData);
                List<SelectListItem> citValues = (from y in citvalues
                                                  select new SelectListItem
                                                  {
                                                      Value = y.city,
                                                      Text = y.city
                                                  }).ToList();
                citValues.Add(new SelectListItem { Value = "", Text = "Şehir Seçiniz", Selected = true });
                ViewBag.citList = citValues;

                return View();
            }
            return View();
        }
    }
}

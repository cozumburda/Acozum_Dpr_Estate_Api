using Acozum_Dpr_Estate_UI.Dtos.CategoryDtos;
using Acozum_Dpr_Estate_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Acozum_Dpr_Estate_UI.ViewComponents.HomePage
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _DefaultFeatureComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Categories/ResultCategoryIncludeProducts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryIncludeProductsDto>>(jsonData);
                List<SelectListItem> catValues = (from z in values
                                                  select new SelectListItem
                                                  {
                                                      Value = z.CategoryID.ToString(),
                                                      Text = z.CategoryName
                                                  }).OrderBy(b => b.Text).ToList();
                catValues.Add(new SelectListItem { Value = "0", Text = "Emlak Türü Seçiniz", Selected = true });
                ViewBag.catList = catValues;
                var populars = values.Select(a => a.CategoryName).Take(3).ToList();
                ViewBag.populars = populars;
                return View();
            }
            return View();
        }
    }
}

using Acozum_Dpr_Estate_UI.Dtos.ProductImageDtos;
using Acozum_Dpr_Estate_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Acozum_Dpr_Estate_UI.ViewComponents.PropertySingle
{
    public class _PropertySingleImagesComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _PropertySingleImagesComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            //int id = int.Parse(ViewData["pId"].ToString());

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"ProductImages/GetProductImageByProductId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetProductImagesByProductIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

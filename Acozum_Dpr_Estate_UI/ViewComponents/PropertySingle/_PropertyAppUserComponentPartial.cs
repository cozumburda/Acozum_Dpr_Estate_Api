using Acozum_Dpr_Estate_UI.Dtos.AppUserDtos;
using Acozum_Dpr_Estate_UI.Models;
using Acozum_Dpr_Estate_UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Acozum_Dpr_Estate_UI.ViewComponents.PropertySingle
{
    public class _PropertyAppUserComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _apiSettings;
        public _PropertyAppUserComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings, ILoginService loginService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _loginService = loginService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //int id = int.Parse(ViewData["pId"].ToString());
            int id = int.Parse(_loginService.GetUserId);
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"AppUsers/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetAppUserByProductIdAppUserDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

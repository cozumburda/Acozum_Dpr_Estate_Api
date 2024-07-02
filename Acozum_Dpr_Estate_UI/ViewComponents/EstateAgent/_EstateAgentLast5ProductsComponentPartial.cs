using Acozum_Dpr_Estate_UI.Dtos.ProductDtos;
using Acozum_Dpr_Estate_UI.Models;
using Acozum_Dpr_Estate_UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Acozum_Dpr_Estate_UI.ViewComponents.EstateAgent
{
    public class _EstateAgentLast5ProductsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _apiSettings;
        public _EstateAgentLast5ProductsComponentPartial(IHttpClientFactory httpClientFactory, ILoginService loginService, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            int id = int.Parse(_loginService.GetUserId);
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync(_apiSettings.BaseUrl + "EstateAgentLastProducts?id=" + id);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}

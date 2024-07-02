﻿using Acozum_Dpr_Estate_UI.Dtos.ProductDtos;
using Acozum_Dpr_Estate_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Acozum_Dpr_Estate_UI.ViewComponents.Dashboard
{
    public class _DashboardLast5ProductComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public _DashboardLast5ProductComponentPartial(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var reponseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Products/Last5ProductList");
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

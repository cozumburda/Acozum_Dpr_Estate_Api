using Acozum_Dpr_Estate_UI.Dtos.ToDoListDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Acozum_Dpr_Estate_UI.ViewComponents.Dashboard
{
    public class _DashboardToDoListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardToDoListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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
    }
}

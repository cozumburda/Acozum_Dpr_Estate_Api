﻿using Acozum_Dpr_Estate_UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Acozum_Dpr_Estate_UI.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        public StatisticsController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            #region Statistics1
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Statistics/ActiveCategoryCount");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            ViewBag.activeCategoryCount = jsonData;
            #endregion

            #region Statistics2
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync(_apiSettings.BaseUrl + "Statistics/ActiveEmployeeCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.activeEmployeeCount = jsonData2;
            #endregion

            #region Statistics3
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync(_apiSettings.BaseUrl + "Statistics/ApartmentCount");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.apartmentCount = jsonData3;
            #endregion

            #region Statistics4
            var client4 = _httpClientFactory.CreateClient();
            var responseMessage4 = await client4.GetAsync(_apiSettings.BaseUrl + "Statistics/AverageProductPriceByRent");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceByRent = jsonData4.Replace(".", ",");
            #endregion

            #region Statistics5
            var client5 = _httpClientFactory.CreateClient();
            var responseMessage5 = await client5.GetAsync(_apiSettings.BaseUrl + "Statistics/AverageProductPriceBySale");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.averageProductPriceBySale = jsonData5.Replace(".", ",");
            #endregion

            #region Statistics6
            var client6 = _httpClientFactory.CreateClient();
            var responseMessage6 = await client6.GetAsync(_apiSettings.BaseUrl + "Statistics/CategoryCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.categoryCount = jsonData6;
            #endregion

            #region Statistics7
            var client7 = _httpClientFactory.CreateClient();
            var responseMessage7 = await client7.GetAsync(_apiSettings.BaseUrl + "Statistics/AverageRoomCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.averageRoomCount = jsonData7;
            #endregion

            #region Statistics8
            var client8 = _httpClientFactory.CreateClient();
            var responseMessage8 = await client8.GetAsync(_apiSettings.BaseUrl + "Statistics/CategoryNameByMaxProductCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.categoryNameByMaxProductCount = jsonData8;
            #endregion

            #region Statistics9
            var client9 = _httpClientFactory.CreateClient();
            var responseMessage9 = await client9.GetAsync(_apiSettings.BaseUrl + "Statistics/CityNameByMaxProductCount");
            var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
            ViewBag.cityNameByMaxProductCount = jsonData9;
            #endregion

            #region Statistics10
            var client10 = _httpClientFactory.CreateClient();
            var responseMessage10 = await client10.GetAsync(_apiSettings.BaseUrl + "Statistics/DifferentCityCount");
            var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
            ViewBag.differentCityCount = jsonData10;
            #endregion

            #region Statistics11
            var client11 = _httpClientFactory.CreateClient();
            var responseMessage11 = await client11.GetAsync(_apiSettings.BaseUrl + "Statistics/EmployeeNameByMaxProductCount");
            var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
            ViewBag.employeeNameByMaxProductCount = jsonData11;
            #endregion

            #region Statistics12
            var client12 = _httpClientFactory.CreateClient();
            var responseMessage12 = await client12.GetAsync(_apiSettings.BaseUrl + "Statistics/LastProductPrice");
            var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
            ViewBag.lastProductPrice = jsonData12.Replace(".", ",");
            #endregion

            #region Statistics13
            var client13 = _httpClientFactory.CreateClient();
            var responseMessage13 = await client13.GetAsync(_apiSettings.BaseUrl + "Statistics/NewestBuildingYear");
            var jsonData13 = await responseMessage13.Content.ReadAsStringAsync();
            ViewBag.newestBuildingYear = jsonData13;
            #endregion

            #region Statistics14
            var client14 = _httpClientFactory.CreateClient();
            var responseMessage14 = await client14.GetAsync(_apiSettings.BaseUrl + "Statistics/OldestestBuildingYear");
            var jsonData14 = await responseMessage14.Content.ReadAsStringAsync();
            var thisyear = DateTime.Now.Year;
            var age = thisyear - (int.Parse(jsonData14));
            ViewBag.oldestestBuildingYear = age;
            #endregion

            #region Statistics15
            var client15 = _httpClientFactory.CreateClient();
            var responseMessage15 = await client15.GetAsync(_apiSettings.BaseUrl + "Statistics/PassiveCategoryCount");
            var jsonData15 = await responseMessage15.Content.ReadAsStringAsync();
            ViewBag.passiveCategoryCount = jsonData15;
            #endregion

            #region Statistics16
            var client16 = _httpClientFactory.CreateClient();
            var responseMessage16 = await client16.GetAsync(_apiSettings.BaseUrl + "Statistics/ProductCount");
            var jsonData16 = await responseMessage16.Content.ReadAsStringAsync();
            ViewBag.productCount = jsonData16;
            #endregion

            return View();
        }
    }
}

﻿using Acozum_Dpr_Estate_UI.Dtos.EmployeeDtos;
using Acozum_Dpr_Estate_UI.Models;
using Acozum_Dpr_Estate_UI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Acozum_Dpr_Estate_UI.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILoginService _loginService;
        private readonly ApiSettings _apiSettings;

        public EmployeeController(IHttpClientFactory httpClientFactory, ILoginService loginService, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _loginService = loginService;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            var user = User.Claims.ToList();
            //var userId = user[1].Value;
            var userId = _loginService.GetUserId;
            var token = User.Claims.FirstOrDefault(x => x.Type == "realestatetoken")?.Value;
            if (token != null)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + "Employees");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var jsonData = await responseMessage.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultEmployeeDto>>(jsonData);
                    return View(values);
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeDto createEmployeeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createEmployeeDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync(_apiSettings.BaseUrl + "Employees", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Personel Eklenmedi");
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync(_apiSettings.BaseUrl + $"Employees/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Personel Silinmedi");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateEmployee(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync(_apiSettings.BaseUrl + $"Employees/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateEmployeeDto>(jsondata);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateEmployeeDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(_apiSettings.BaseUrl + "Employees", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Personel Güncellenmedi");
        }
        public async Task<IActionResult> ChangeStatusEmployee(int id, UpdateEmployeeDto updateEmployeeDto)
        {
            updateEmployeeDto.EmployeeID = 0;
            updateEmployeeDto.Name = "string";
            updateEmployeeDto.Title = "string";
            updateEmployeeDto.Mail = "string";
            updateEmployeeDto.PhoneNumber = "string";
            updateEmployeeDto.ImageUrl = "string";
            updateEmployeeDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(updateEmployeeDto);
            StringContent stringContent = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync(_apiSettings.BaseUrl + $"Employees/{id}", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View("Durum Değiştirilemedi_1!");
        }
    }
}

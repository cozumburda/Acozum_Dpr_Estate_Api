using Acozum_Dpr_Estate_Api.Repositories.EstateAgentRepositories.DashboardRepositories.LastProductsRepositories;
using Acozum_Dpr_Estate_Api.Repositories.ProductRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstateAgentLastProductsController : ControllerBase
    {
        private readonly ILast5ProductsRepository _last5ProductsRepository;

        public EstateAgentLastProductsController(ILast5ProductsRepository last5ProductsRepository)
        {
            _last5ProductsRepository = last5ProductsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetLast5ProductsAsync(int id) 
        {
          var values= await _last5ProductsRepository.GetLast5ProductAsync(id);
            return Ok(values);
        }
    }
}

using Acozum_Dpr_Estate_Api.Dtos.LoginDtos;
using Acozum_Dpr_Estate_Api.Models.DapperContext;
using Acozum_Dpr_Estate_Api.Tools;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acozum_Dpr_Estate_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(CreateLoginDto loginDto)
        {
            string query = "select * from AppUser where UserName=@username and Password=@password";
            string query2 = "select UserID, RoleName from AppUser inner join AppRole on RoleID=UserRole where UserName=@username and Password=@password";
            var parameters = new DynamicParameters();
            parameters.Add("@username", loginDto.UserName);
            parameters.Add("@password", loginDto.Password);
            using(var connection=_context.CreateConnection())
            {
                var values=await connection.QueryFirstOrDefaultAsync<CreateLoginDto>(query,parameters);
                var values2=await connection.QueryFirstOrDefaultAsync<CreateAppUserIdDto>(query2,parameters);
                if (values != null)
                {
                    GetCheckAppUserViewModel model=new GetCheckAppUserViewModel();
                    model.UserName=values.UserName;
                    model.Id = values2.UserID;
                    model.Role = values2.RoleName;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return NotFound("Başarısız");
                }
            }
        }
    }
}

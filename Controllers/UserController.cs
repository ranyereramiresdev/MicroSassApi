using MicroSassApi.Helpers;
using MicroSassApi.Helpers.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MicroSassApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpPost]
        [Route("Login")]

        public async Task<IActionResult> Login([FromBody] UserLoginDTO body)
        {
            try
            {
                return Ok(body);
            }
            catch (Exception e)
            {
                ResulApiDTO result = new ResulApiDTO();
                result.StatusCode = 409;
                result.Message = "Houve um erro interno relacionado a Api";
                result.Error = e.Message;
                result.ErrorDescription = e.Message;

                return StatusCode(result.StatusCode, result);
            }
        }
    }
}

using MicroSassApi.Helpers;
using MicroSassApi.Helpers.Authentication;
using MicroSassApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroSassApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO body)
        {
            try
            {
                var result = await _userRepository.LoginAsync(body.Email, body.Password);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    ResulApiDTO resultNotFound = new ResulApiDTO();
                    resultNotFound.StatusCode = 401;
                    resultNotFound.Message = "Erro ao logar";
                    resultNotFound.Error = "Usuário e senha incorretos";
                    resultNotFound.ErrorDescription = "Usuário e senha incorretos";

                    return StatusCode(resultNotFound.StatusCode, resultNotFound);
                }
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

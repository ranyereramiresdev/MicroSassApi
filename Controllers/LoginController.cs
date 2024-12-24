using System.Security.Claims;
using MicroSassApi.Helpers;
using MicroSassApi.Helpers.Authentication;
using MicroSassApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroSassApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthenticationHelper _authenticationHelper;

        public LoginController(IUserRepository UserRepositor, IAuthenticationHelper AuthenticationHelper)
        {
            _userRepository = UserRepositor;
            _authenticationHelper = AuthenticationHelper;
        }

        [HttpPost]
        [Route("Generate-Token")]
        public async Task<IActionResult> Login([FromBody] UserLoginDTO body)
        {
            try
            {
                var result = await _userRepository.LoginAsync(body.Email, body.Password);

                if (result != null)
                {
                    var token = _authenticationHelper.GenerateToken(result);

                    return Ok(new
                    {
                        Tipo = "Bearer",
                        Token = token,
                        Duração = "1 hora"
                    });
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

        [HttpPost]
        [Route("ValidateToken")]
        [Authorize(Roles = "1,2")]

        public async Task<IActionResult> ValidateToken()
        {
            try
            {
                var claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList();

                return Ok(
                    User.Claims
                        .Where(c => c.Type == "Id" || c.Type == "IdResponsavel" || c.Type == ClaimTypes.Role)
                        .ToDictionary(c => c.Type, c => c.Value)
                );
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

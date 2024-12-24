using System.Security.Claims;
using MicroSassApi.Helpers;
using MicroSassApi.Helpers.Authentication;
using MicroSassApi.Repositories.Interfaces;
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

        /// <summary>
        /// Gera o token de acesso para consumir as outras rotas
        /// </summary>
        /// <param name="body"></param>
        /// <returns>Retorna o token de acesso</returns>
        [HttpPost]
        [Route("Generate-Token")]
        [ProducesResponseType(typeof(string), 200)]
        [ProducesResponseType(typeof(ResulApiDTO), 409)]
        public async Task<IActionResult> GenerateToken([FromBody] UserLoginDTO body)
        {
            try
            {
                var result = await _userRepository.LoginAsync(body.Email, body.Password);

                if (result != null)
                {
                    var token = _authenticationHelper.GenerateToken(result);

                    return Ok(token);
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

        /// <summary>
        /// Valida o token de acesso e retornar as claims
        /// </summary>
        /// <returns>Retorna uma lista com as 3 principais claims</returns>
        [HttpPost]
        [Route("ValidateToken")]
        [ProducesResponseType(typeof(Dictionary<string, string>), 200)]
        [ProducesResponseType(typeof(ResulApiDTO), 409)]

        public async Task<IActionResult> ValidateToken()
        {
            try
            {
                var filteredClaim = User.Claims
                        .Where(c => c.Type == "Id" || c.Type == "IdResponsavel" || c.Type == ClaimTypes.Role)
                        .ToDictionary(c => c.Type, c => c.Value);

                return Ok(filteredClaim);
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

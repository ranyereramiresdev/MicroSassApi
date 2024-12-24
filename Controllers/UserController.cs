using MicroSassApi.Helpers;
using MicroSassApi.Models;
using MicroSassApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MicroSassApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private IUserRepository _userRepository;
        public UserController(IUserRepository UserRepository)
        {
            _userRepository = UserRepository;
        }

        /// <summary>
        /// Adicionar um usuário
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Objeto informando o resultado da ação</returns>
        [HttpPost]
        [Route("Add")]
        [ProducesResponseType(typeof(ResulApiDTO), 200)]
        [ProducesResponseType(typeof(ResulApiDTO), 409)]

        public async Task<IActionResult> Add([FromBody] UsuarioModel usuario)
        {
            ResulApiDTO result = new ResulApiDTO();
            try
            {
                await _userRepository.Add(usuario);

                result.StatusCode = 201;
                result.Message = "Usuário adicionado com sucesso";
                result.Error = null;
                result.ErrorDescription = null;

                return StatusCode(result.StatusCode, result);
            }
            catch (Exception e)
            {
                result.StatusCode = 409;
                result.Message = "Houve um erro interno relacionado a Api";
                result.Error = e.Message;
                result.ErrorDescription = e.Message;

                return StatusCode(result.StatusCode, result);
            }
        }
    }
}

using MicroSassApi.Helpers;
using MicroSassApi.Models;
using MicroSassApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroSassApi.Controllers
{
    [Route("Api/[controller]")]
    [ApiController]
    public class UserTypeController : Controller
    {
        private IUserTypeRepository _userTypeRepository;
        public UserTypeController(IUserTypeRepository UserTypeRepository)
        {
            _userTypeRepository = UserTypeRepository;
        }

        /// <summary>
        /// Adicionar tipo de usuário
        /// </summary>
        /// <param name="description"></param>
        /// <returns>Objeto informando o resultado da ação</returns>
        [HttpPost]
        [Route("Add/{description}")]
        [Authorize(Roles = "3")]
        [ProducesResponseType(typeof(ResulApiDTO), 200)]
        [ProducesResponseType(typeof(ResulApiDTO), 409)]
        public async Task<IActionResult> Add(string description)
        {
            ResulApiDTO result = new ResulApiDTO();
            try
            {
                TipoUsuarioModel tipoUsuario = new TipoUsuarioModel();
                tipoUsuario.Id = 0;
                tipoUsuario.Descricao = description;

                await _userTypeRepository.Add(tipoUsuario);

                result.StatusCode = 201;
                result.Message = "Tipo de usuário adicionado com sucesso";
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

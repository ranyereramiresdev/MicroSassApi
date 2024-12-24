using MicroSassApi.Models;

namespace MicroSassApi.Repositories.Interfaces
{
    public interface IUserTypeRepository
    {
        Task Add(TipoUsuarioModel usuario);
    }
}

using MicroSassApi.Models;

namespace MicroSassApi.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UsuarioModel?> LoginAsync(string email, string senha);
    }
}

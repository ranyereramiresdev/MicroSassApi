using MicroSassApi.Models;

namespace MicroSassApi.Helpers.Authentication
{
    public interface IAuthenticationHelper
    {
        string GenerateToken(UsuarioModel user);
        string EncryptWithMd5(string input);
    }
}

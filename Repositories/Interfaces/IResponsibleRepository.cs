using MicroSassApi.Models;

namespace MicroSassApi.Repositories.Interfaces
{
    public interface IResponsibleRepository
    {
        Task Add(ResponsavelModel reponsible);
    }
}

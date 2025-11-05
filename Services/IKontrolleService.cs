
namespace DotNet8.WebApi.Services
{
    using DotNet8.WebApi.Dtos;
    using DotNet8.WebApi.Entities;
    public interface IKontrolleService
    {
        Task<Kontrolle> CreateKontrolleAsync(CreateKontrolleDto request, int userId);
        Task<List<Kontrolle>> GetKontrollenByBaumIdAsync(int baumId, int userId);
        Task<List<Kontrolle>> GetAllKontrollenAsync(int userId);
        Task<Kontrolle> GetKontrolleByIdAsync(int kontrolleId, int userId);
        Task<bool> DeleteKontrolleAsync(int kontrolleId, int userId);

    }
}

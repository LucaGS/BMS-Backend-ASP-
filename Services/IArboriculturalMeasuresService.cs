using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;

namespace DotNet8.WebApi.Services
{
    public interface IArboriculturalMeasuresService
    {
        Task<IEnumerable<ArboriculturalMeasure>> GetArboriculturalMeasuresAsync(int userId);
        Task<ArboriculturalMeasure> CreateArboriculturalMeasureAsync(CreateArboriculturalMeasuresDto measure, int UserId);
        Task<ArboriculturalMeasure?> UpdateArboriculturalMeasureAsync(int id, UpdateArboriculturalMeasuresDto request, int userId);
        Task<bool> DeleteArboriculturalMeasureAsync(int id, int userId);
    }
}

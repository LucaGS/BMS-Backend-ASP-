using DotNet8.WebApi.Dtos;

namespace DotNet8.WebApi.Services
{
    public interface IArboriculturalMeasuresService
    {
        Task<IEnumerable<Entities.ArboriculturalMeasure>> GetArboriculturalMeasuresAsync(int userId);
        Task<Entities.ArboriculturalMeasure> CreateArboriculturalMeasureAsync(CreateArboriculturalMeasuresDto measure, int UserId);
    }
}

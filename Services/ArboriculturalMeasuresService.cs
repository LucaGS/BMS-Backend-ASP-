using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;

namespace DotNet8.WebApi.Services
{
    public class ArboriculturalMeasuresService(AppDbContext _context) : IArboriculturalMeasuresService
    {
        public Task<ArboriculturalMeasure> CreateArboriculturalMeasureAsync(CreateArboriculturalMeasuresDto requst, int UserId)
        {
            ArboriculturalMeasure measure = new()
            {
                MeasureName = requst.MeasureName,
                Description = requst.Description,
                UserId = UserId
            };
            _context.ArboriculturalMeasures.Add(measure);
            _context.SaveChanges();
            return Task.FromResult(measure);
        }

        public Task<IEnumerable<ArboriculturalMeasure>> GetArboriculturalMeasuresAsync(int userId)
        {
            return Task.FromResult(_context.ArboriculturalMeasures.Where(m => m.UserId == userId).AsEnumerable());
        }
    }
}

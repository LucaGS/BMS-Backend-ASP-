using DotNet8.WebApi.Data;
using DotNet8.WebApi.Dtos;
using DotNet8.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ArboriculturalMeasure?> UpdateArboriculturalMeasureAsync(int id, UpdateArboriculturalMeasuresDto request, int userId)
        {
            var measure = await _context.ArboriculturalMeasures.SingleOrDefaultAsync(m => m.Id == id && m.UserId == userId);
            if (measure == null)
            {
                return null;
            }

            measure.MeasureName = request.MeasureName;
            measure.Description = request.Description;

            await _context.SaveChangesAsync();
            return measure;
        }

        public async Task<bool> DeleteArboriculturalMeasureAsync(int id, int userId)
        {
            var measure = await _context.ArboriculturalMeasures.SingleOrDefaultAsync(m => m.Id == id && m.UserId == userId);
            if (measure == null)
            {
                return false;
            }

            _context.ArboriculturalMeasures.Remove(measure);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

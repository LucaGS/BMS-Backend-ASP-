namespace DotNet8.WebApi.Services
{
    using DotNet8.WebApi.Data;
    using DotNet8.WebApi.Dtos;
    using DotNet8.WebApi.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class KontrolleService(AppDbContext context) : IKontrolleService
    {
        public async Task<Kontrolle> CreateKontrolleAsync(CreateKontrolleDto request, int userId)
        {
            Kontrolle kontrolle = new Kontrolle
            {
                BaumId = request.BaumId,
                Datum = DateTime.Now,
                Verkehrssicher = request.Verkehrssicher,
                UserId = userId
            };
            context.Kontrollen.Add(kontrolle);
            await context.SaveChangesAsync();
            return kontrolle;                              
        }

        public Task<bool> DeleteKontrolleAsync(int kontrolleId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Kontrolle>> GetAllKontrollenAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<Kontrolle> GetKontrolleByIdAsync(int kontrolleId, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Kontrolle>> GetKontrollenByBaumIdAsync(int baumId, int userId)
        {
            List<Kontrolle> kontrollen = context.Kontrollen.Where(k => k.BaumId == baumId).ToList();
            return Task.FromResult(kontrollen);
        }
    }
}

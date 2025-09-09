namespace DotNet8.WebApi.Services
{
    public interface IBaumService
    {
        Task<int> CreateBaumAsync(int nummer, string art);
        Task<int> UpdateBaumAsync(int id, int nummer, string art);
    }
}

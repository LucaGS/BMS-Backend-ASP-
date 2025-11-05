namespace DotNet8.WebApi.Services
{
    using DotNet8.WebApi.Dtos;
    using DotNet8.WebApi.Entities;

    public interface IInspectionService
    {
        Task<Inspection> CreateInspectionAsync(CreateInspectionDto request, int userId);
        Task<List<Inspection>> GetInspectionsByTreeIdAsync(int treeId, int userId);
        Task<List<Inspection>> GetAllInspectionsAsync(int userId);
        Task<Inspection> GetInspectionByIdAsync(int inspectionId, int userId);
        Task<bool> DeleteInspectionAsync(int inspectionId, int userId);
    }
}

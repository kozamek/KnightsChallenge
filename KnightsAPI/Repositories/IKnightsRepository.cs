using KnightsAPI.Entities;

namespace KnightsAPI.Repositories
{
    public interface IKnightsRepository
    {
        Task<IEnumerable<Knight>> GetHeroes();
        Task<IEnumerable<Knight>> GetKnights();
        Task<Knight> GetKnight(string id);
        Task CreateKnight(Knight knight);
        Task<bool> UpdateKnight(Knight knight);
        Task<bool> DeleteKnight(string id);
    }
}

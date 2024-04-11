using KnightsAPI.Entities;
using MongoDB.Driver;

namespace KnightsAPI.Data
{
    public interface IKnightsContext
    {
        IMongoCollection<Knight> Knights { get; }
    }
}

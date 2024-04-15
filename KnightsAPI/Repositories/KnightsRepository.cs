using KnightsAPI.Data;
using KnightsAPI.Entities;
using MongoDB.Driver;

namespace KnightsAPI.Repositories
{
    public class KnightsRepository : IKnightsRepository
    {
        private readonly IKnightsContext _context;

        public KnightsRepository(IKnightsContext context)
        { 
            _context = context;
        }

        public async Task CreateKnight(Knight knight)
        {
            await _context.Knights.InsertOneAsync(knight);
        }

        public async Task<bool> DeleteKnight(string id)
        {
            FilterDefinition<Knight> filter = Builders<Knight>.Filter.Eq(p => p.Id, id);
            var update = Builders<Knight>.Update.Set(p => p.Hero, true);

            var updateResult = await _context.Knights.UpdateOneAsync(filter, update);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        public async Task<IEnumerable<Knight>> GetHeroes()
        {
            FilterDefinition<Knight> filter = Builders<Knight>.Filter.Eq(p => p.Hero, true);

            return await _context.Knights.Find(filter).ToListAsync();
        }

        public async Task<Knight> GetKnight(string id)
        {
            return await _context.Knights.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Knight>> GetKnights()
        {
            FilterDefinition<Knight> filter = Builders<Knight>.Filter.Eq(p => p.Hero, false);

            return await _context.Knights.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateKnight(string id, string newName)
        {
            FilterDefinition<Knight> filter = Builders<Knight>.Filter.Eq(p => p.Id, id);
            var update = Builders<Knight>.Update.Set(p => p.Name, newName);

            var updateResult = await _context.Knights.UpdateOneAsync(filter, update);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}

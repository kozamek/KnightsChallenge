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

            DeleteResult deleteResult = await _context.Knights.DeleteOneAsync(filter);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
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
            return await _context.Knights.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateKnight(Knight knight)
        {
            var updateResult = await _context.Knights.ReplaceOneAsync(filter: g => g.Id == knight.Id, replacement: knight);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}

using ECF.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ECF.Services
{
    public class StatistiquesService
    {
        private readonly IMongoCollection<Statistiques> _statistiquesCollection;

        public StatistiquesService(
            IOptions<StatistiquesDatabaseSettings> statistiquesStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                statistiquesStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                statistiquesStoreDatabaseSettings.Value.DatabaseName);

            _statistiquesCollection = mongoDatabase.GetCollection<Statistiques>(
                statistiquesStoreDatabaseSettings.Value.StatistiquesCollectionName);
        }

        public async Task<List<Statistiques>> GetAsync() =>
            await _statistiquesCollection.Find(_ => true).ToListAsync();

        public async Task<Statistiques?> GetAsync(string id) =>
            await _statistiquesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Statistiques newStat) =>
            await _statistiquesCollection.InsertOneAsync(newStat);

        public async Task UpdateAsync(string id, Statistiques updatedStat) =>
            await _statistiquesCollection.ReplaceOneAsync(x => x.Id == id, updatedStat);

        public async Task RemoveAsync(string id) =>
            await _statistiquesCollection.DeleteOneAsync(x => x.Id == id);
    }
}

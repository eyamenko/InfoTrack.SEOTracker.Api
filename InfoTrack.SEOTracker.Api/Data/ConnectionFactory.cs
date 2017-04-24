using MongoDB.Driver;
using InfoTrack.SEOTracker.Api.Contracts.Data;

namespace InfoTrack.SEOTracker.Api.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly MongoClient _client;

        public ConnectionFactory(string connectionString)
        {
            _client = new MongoClient(connectionString);
        }

        public IMongoClient Get()
        {
            return _client;
        }
    }
}
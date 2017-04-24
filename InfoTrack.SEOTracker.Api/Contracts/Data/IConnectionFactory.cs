using MongoDB.Driver;

namespace InfoTrack.SEOTracker.Api.Contracts.Data
{
    public interface IConnectionFactory
    {
        IMongoClient Get();
    }
}
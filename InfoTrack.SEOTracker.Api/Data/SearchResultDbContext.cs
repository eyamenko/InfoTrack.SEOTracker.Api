using InfoTrack.SEOTracker.Api.Contracts.Data;
using MongoDB.Driver;
using InfoTrack.SEOTracker.Api.Models;

namespace InfoTrack.SEOTracker.Api.Data
{
    public class SearchResultDbContext : ISearchResultDbContext
    {
        private readonly IMongoDatabase _database;

        public SearchResultDbContext(IConnectionFactory connectionFactory)
        {
            _database = connectionFactory.Get().GetDatabase("SEOTracker");
        }

        public IMongoCollection<SearchResult> SearchResults => _database.GetCollection<SearchResult>("SearchResults");
    }
}
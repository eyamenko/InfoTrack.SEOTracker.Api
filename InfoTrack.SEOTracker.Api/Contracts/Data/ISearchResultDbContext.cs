using InfoTrack.SEOTracker.Api.Models;
using MongoDB.Driver;

namespace InfoTrack.SEOTracker.Api.Contracts.Data
{
    public interface ISearchResultDbContext
    {
        IMongoCollection<SearchResult> SearchResults { get; }
    }
}
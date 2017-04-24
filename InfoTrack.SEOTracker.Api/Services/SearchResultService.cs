using System;
using InfoTrack.SEOTracker.Api.Contracts.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using InfoTrack.SEOTracker.Api.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using InfoTrack.SEOTracker.Api.Contracts.Services;

namespace InfoTrack.SEOTracker.Api.Services
{
    public class SearchResultService : ISearchResultService
    {
        private readonly ISearchResultDbContext _dbContext;

        public SearchResultService(ISearchResultDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Create(IEnumerable<SearchPosition> positions)
        {
            var document = new SearchResult
            {
                Timestamp = DateTime.UtcNow,
                Data = positions
            };

            return _dbContext.SearchResults.InsertOneAsync(document);
        }

        public Task<SearchResult> GetLatest()
        {
            return _dbContext.SearchResults.AsQueryable().OrderByDescending(sr => sr.Timestamp).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SearchResult>> GetAll()
        {
            return await _dbContext.SearchResults.AsQueryable().OrderBy(sr => sr.Timestamp).ToListAsync();
        }
    }
}
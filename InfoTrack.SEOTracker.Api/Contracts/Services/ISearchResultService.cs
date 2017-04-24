using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using InfoTrack.SEOTracker.Api.Models;

namespace InfoTrack.SEOTracker.Api.Contracts.Services
{
    public interface ISearchResultService
    {
        Task Create(IEnumerable<SearchPosition> positions);
        Task<SearchResult> GetLatest();
        Task<IEnumerable<SearchResult>> GetAll();
    }
}
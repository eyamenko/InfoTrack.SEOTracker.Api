using System;
using Microsoft.AspNetCore.Mvc;
using InfoTrack.SEOTracker.Api.Contracts.Services;
using System.Threading.Tasks;
using System.Collections.Generic;
using InfoTrack.SEOTracker.Api.Models;

namespace InfoTrack.SEOTracker.Api.Controllers
{
    [Route("v1/[controller]")]
    public class SearchResultsController : Controller
    {
        private readonly ISearchResultService _searchResultService;

        public SearchResultsController(ISearchResultService searchResultService)
        {
            _searchResultService = searchResultService;
        }

        [HttpGet("latest")]
        public async Task<IActionResult> GetLatest()
        {
            try
            {
                var searchResult = await _searchResultService.GetLatest();

                if (searchResult == null)
                    return NotFound();

                return Ok(searchResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var searchResults = await _searchResultService.GetAll();

                return Ok(searchResults);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] IEnumerable<SearchPosition> positions)
        {
            try
            {
                await _searchResultService.Create(positions);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace InfoTrack.SEOTracker.Api.Models
{
    [BsonIgnoreExtraElements]
    public class SearchResult
    {
        public DateTime Timestamp
        {
            get;
            set;
        }

        public IEnumerable<SearchPosition> Data
        {
            get;
            set;
        }
    }
}
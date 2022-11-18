using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Penalty.Penalty.ODDSApiMatches
{
    public class ODDSMatch 
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("sport_key")]
        public string SportKey { get; set; }
        [JsonPropertyName("sport_title")]
        public string SportTitle { get; set; }
        [JsonPropertyName("commence_time")]
        public DateTime CommenceTime { get; set; }
        [JsonPropertyName("completed")]
        public bool Completed { get; set; }
        [JsonPropertyName("home_team")]
        public string HomeTeam { get; set; }
        [JsonPropertyName("away_team")]
        public string AwayTeam { get; set; }
        [JsonPropertyName("scores")]
        public List<Score> Scores { get; set; }
    }
}

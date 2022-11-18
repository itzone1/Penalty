using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Penalty.Penalty.ODDSApiMatches
{
    public class Score
    {
        [JsonPropertyName("name")]
        public string TeamName { get; set; }
        [JsonPropertyName("score")]
        public int TeamScore { get; set; }
    }
}

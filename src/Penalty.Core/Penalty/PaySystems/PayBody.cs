using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Penalty.Penalty.PaySystems
{
    public class PayBody
    {
        [JsonPropertyName("account")]
        public string account { get; set; }
        [JsonPropertyName("apiId")]
        public string apiId { get; set; }
        [JsonPropertyName("apiPass")]
        public string apiPass { get; set; }
        [JsonPropertyName("action")]
        public string action { get; set; }
        [JsonPropertyName("merchantId")]
        public string merchantId { get; set; }
        [JsonPropertyName("referenceId")]
        public string referenceId { get; set; }

    }
}

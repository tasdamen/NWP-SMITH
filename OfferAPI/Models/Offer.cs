using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace OfferAPI
{
    public class Offer
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("EligibleProducts")]
        public List<int> EligibleProducts { get; set; }

        [JsonProperty("Discount")]
        public int Discount { get; set; }

        [JsonProperty("Expiration")]
        public DateTime Expiration { get; set; }
    }
}

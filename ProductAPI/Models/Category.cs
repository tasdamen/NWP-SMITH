using System;
using Newtonsoft.Json;

namespace ProductAPI
{
   public class Category
    {
        [JsonProperty("id")]
        public int CategoryID { get; set; }

        [JsonProperty("name")]
        public int CategoryName { get; set; }

        [JsonProperty("description")]
        public int CategoryDescription { get; set; }


    }
}

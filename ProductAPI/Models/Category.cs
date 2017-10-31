using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class Category
    {
        [JsonProperty("categoryID")]
        public int CategoryID { get; set; }

        [JsonProperty("categoryName")]
        public int CategoryName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

   
}

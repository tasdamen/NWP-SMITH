using Newtonsoft.Json;
using System;

namespace ProductAPI
{
    public class Product 
    {
        [JsonProperty("id")]
        public int ProductID { get; set; }
        [JsonProperty("name")]
        public string ProductName { get; set; }
        [JsonProperty("qtyPerUnit")]
        public string QuantityPerUnit { get; set; }
        [JsonProperty("price")]
        public decimal UnitPrice { get; set; }
        [JsonProperty("stockQty")]
        public int UnitsInStock { get; set; }
        [JsonProperty("onOrder")]
        public int UnitsOnOrder { get; set; }
        [JsonProperty("reorderLevel")]
        public Int16 ReorderLevel { get; set; }
        [JsonProperty("discontinued")]
        public Boolean Discontinued { get; set; }
    }
}

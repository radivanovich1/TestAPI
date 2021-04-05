using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestAPI
{
    public class  LocationResponse 
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("location_type")]
        public string LocationType { get; set; }
        
        [JsonProperty("woeid")]
        public string Woeid { get; set; }

        [JsonProperty("latt_long")]
        public string LattLong { get; set; }
    }
}

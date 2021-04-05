using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestAPI
{
    public class WeatherResponseList
    {
        
        [JsonProperty("consolidated_weather")]
        public List<WeatherResponse> wth { get; set; }
        public int count { get; set; }


    }
}

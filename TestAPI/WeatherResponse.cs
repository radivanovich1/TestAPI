using System;
using Newtonsoft.Json;

namespace TestAPI
{
    public class WeatherResponse
    {
        
        [JsonProperty("min_temp")]
        public string MinTemp { get; set; }

        [JsonProperty("max_temp")]
        public string MaxTemp { get; set; }

        [JsonProperty("applicable_date")]
        public string AppDate { get; set; }

        [JsonProperty("the_temp")]
        public string The_temp { get; set; }

        [JsonProperty("weather_state_name")]
        public string WeatherStateName { get; set; }
        

    }
}

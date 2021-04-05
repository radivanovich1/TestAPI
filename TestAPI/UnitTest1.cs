using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace TestAPI
{
    public class Tests
    {
        private const string BASE_URL = "https://www.metaweather.com/api";
        static readonly HttpClient client = new HttpClient();
        private string latt_long = "53.90255,27.563101";
        private string woeid;
        private float min_temp = -1;
        private float max_temp = 15;
        private string pas_date = DateTime.Now.AddYears(-5).ToString("yyyy/MM/dd");
  

        [SetUp]
        public void Setup()
        {

        }
        

        [Test]
        public async Task CheckMinsk()
        {
            HttpResponseMessage response = await client.GetAsync(BASE_URL+ "/location/search/?query=min");
            string responseBody = await response.Content.ReadAsStringAsync();
            LocationResponse [] locationResponse = JsonConvert.DeserializeObject<LocationResponse[]>(responseBody);
            foreach (var item in locationResponse)
            {
                if (item.Title.Equals("Minsk") && item.LattLong.Equals(latt_long))
                {
                    woeid = item.Woeid;

                }

            }
            Assert.True(woeid!=null);
        }

        [Test]
        public async Task TodayWeather()
        {
            HttpResponseMessage response = await client.GetAsync(BASE_URL + $"/location/{woeid}");
            string responseBody = await response.Content.ReadAsStringAsync();
            WeatherResponseList weatherResponses = JsonConvert.DeserializeObject<WeatherResponseList>(responseBody);
            foreach (var item in weatherResponses.wth)
            {
                if (item.AppDate.Equals(System.DateTime.Now.Date.ToString("yyyy-MM-dd")))
                {
                    Assert.Pass();
                }
            }

        }

        [Test]
        public async Task TemperatureInterval()
        {
            HttpResponseMessage response = await client.GetAsync(BASE_URL + $"/location/{woeid}");
            string responseBody = await response.Content.ReadAsStringAsync();
            WeatherResponseList weatherResponses = JsonConvert.DeserializeObject<WeatherResponseList>(responseBody);
            foreach (var item in weatherResponses.wth)
            {
                if (float.Parse(item.The_temp) > min_temp && float.Parse(item.The_temp) < max_temp)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }

        }

        [Test]
        public async Task PastWeather()
        {
            HttpResponseMessage response = await client.GetAsync(BASE_URL + $"/location/{woeid}/{pas_date}");
            string responseBody = await response.Content.ReadAsStringAsync();
            WeatherResponse[] weatherResponses = JsonConvert.DeserializeObject<WeatherResponse[]>(responseBody);
            foreach (var item in weatherResponses)
            {
                if (item.WeatherStateName!=null)
                {
                    Assert.Pass();
                }
               
            }
            Assert.Fail();

        }
    }
}


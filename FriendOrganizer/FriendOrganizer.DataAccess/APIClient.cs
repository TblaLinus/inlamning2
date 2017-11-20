using FriendOrganizer.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.DataAccess
{
    public class APIClient : IAPIClient
    {
        public HttpClient httpClient = new HttpClient { BaseAddress = new Uri("https://www.metaweather.com/api/") };

        public async Task<Weather> RunAsync(DateTime dateTime)
        {
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Weather weather;
            try
            {
                //location/890869 == Gothenburg
                weather = await GetWeatherAsync($"location/890869/{dateTime.Year}/{dateTime.Month}/{dateTime.Day}/");
            }
            catch
            {
                weather = new Weather
                {
                    applicable_date = $"{dateTime.Year}/{dateTime.Month}/{dateTime.Day}",
                    weather_state_name = "forecast\nunavailable",
                    min_temp = 0,
                    max_temp = 0
                };
            }
            return weather;
        }

        private async Task<Weather> GetWeatherAsync(string path)
        {
            HttpResponseMessage response = await httpClient.GetAsync(path);
            var jsonString = await response.Content.ReadAsStringAsync();
            var weatherList = JsonConvert.DeserializeObject<List<Weather>>(jsonString);
            return weatherList[0];
        }
    }
}

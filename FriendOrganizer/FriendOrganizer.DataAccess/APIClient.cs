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
        public HttpClient httpClient = new HttpClient();

        public async Task<Weather> RunAsync()
        {
            httpClient.BaseAddress = new Uri("https://www.metaweather.com/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Weather weather = await GetWeatherAsync("location/44418/2013/4/27/");
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

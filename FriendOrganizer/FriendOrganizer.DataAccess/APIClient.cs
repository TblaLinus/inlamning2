using FriendOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.DataAccess
{
    public static class APIClient
    {
        static HttpClient httpClient = new HttpClient();

        public static async Task RunAsync()
        {
            //https://www.metaweather.com/api/location/44418/

            httpClient.BaseAddress = new Uri("https://www.metaweather.com/api/");
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Weather weather = await GetWeatherAsync("location/44418/");

        }

        static async Task<Weather> GetWeatherAsync(string path)
        {
            Weather weather = null;
            HttpResponseMessage response = await httpClient.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                weather = await response.Content.ReadAsAsync<Weather>();
            }
            return weather;
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Classes;

namespace WeatherApp.ViewModel
{
    class WeatherAPI
    {
        static string API_KEY = "494b0663ebf499ad10c18868451044bf";
        static string BASE_URL = "https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}";

        public static WeatherData GetWeatherData(string cityName)
        {
            WeatherData result = new WeatherData();

            string url = string.Format(BASE_URL, cityName, API_KEY);

            HttpClient client = new HttpClient();
            var response = client.GetAsync(url);
            string resultString = response.Result.Content.ReadAsStringAsync().Result;
            client.Dispose();

            // string 을 인자로 받아서 WeatherData로 반환
            result = JsonConvert.DeserializeObject<WeatherData>(resultString);
            return result;
        }
    }
}

using System.Net.Http;
using System.Threading.Tasks;

namespace Lab01
{
    class OpenWeatherContentGetter
    {
        static string apiKey = "1b6714e500f0cdd864a8b49ec6ac5e45"; ///@todo: change to my API
        static string apiBaseUrl = "https://api.openweathermap.org/data/2.5/weather";

        private static string buildCityLink(string city)
        {
            return apiBaseUrl + "?q=" + city + "&apikey=" + apiKey + "&mode=xml";
        }

        public static async Task<string> getCityWeatherContentAsStringAsync(string city)
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync(buildCityLink(city)))
            using (HttpContent content = response.Content)
            {
                return await content.ReadAsStringAsync();
            }
        }
    }
}

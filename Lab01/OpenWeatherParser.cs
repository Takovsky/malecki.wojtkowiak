using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Lab01
{
    class OpenWeatherParser
    {
        ///@todo: check for exception and implement wind parsing as now its hard coded
        public static WeatherData parseLinq(Stream stream)
        {
            WeatherData weatherData = new WeatherData();

            XElement xml = XElement.Load(stream);
            var city = ( from element in xml.Elements()
                         where element.Name == "city"
                         select new
                         {
                             City = element.Attributes("name").FirstOrDefault(),
                         } );
            weatherData.city = city.FirstOrDefault().City.Value;

            var temperature = ( from element in xml.Elements()
                                where element.Name == "temperature"
                                select new
                                {
                                    Temperature = element.Attributes("value").FirstOrDefault(),
                                } );
            weatherData.temperature = float.Parse(
                    temperature.FirstOrDefault().Temperature.Value,
                    System.Globalization.CultureInfo.InvariantCulture);

            var wind = ( from element in xml.Elements()
                         where element.Name == "wind"
                         select new
                         {
                             Wind = element.Attributes("name").FirstOrDefault(),
                         } );
            weatherData.wind = "wind";

            return weatherData;
        }

        public static WeatherData parseXmlReader(Stream stream)
        {
            WeatherData weatherData = new WeatherData();
            XmlTextReader reader = new XmlTextReader(stream);

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        switch (reader.Name)
                        {
                            case "city":
                                weatherData.city = reader.GetAttribute("name");
                                break;
                            case "temperature":
                                weatherData.temperature =
                                    float.Parse(
                                        reader.GetAttribute("value"),
                                        System.Globalization.CultureInfo.InvariantCulture);
                                break;
                            case "speed":
                                weatherData.wind = reader.GetAttribute("name");
                                break;
                        }
                        break;
                }
            }

            return weatherData;
        }
    }
}

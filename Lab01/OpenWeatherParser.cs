using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Lab01
{
    class OpenWeatherParser
    {
        public static WeatherData parseLinq(Stream stream)
        {
            WeatherData weatherData = new WeatherData();

            XElement xml = XElement.Load(stream);
            var city = ( from element in xml.Elements()
                         where element.Name.Equals("city")
                         select element.Attribute("name") );
            weatherData.city = city.ToString();

            var temperature = ( from element in xml.Elements()
                                where element.Name == "temperature"
                                select element.Attribute("value") );
            weatherData.temperature = float.Parse(temperature.ToString());

            var wind = ( from element in xml.Elements()
                         where element.Name == "speed"
                         select element.Attribute("name") );
            weatherData.wind = temperature.ToString();

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

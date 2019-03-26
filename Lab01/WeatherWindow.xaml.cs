using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab01
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WeatherWindow : Window
    {
        private List<string> currentCities = new List<string>();
        bool parserChange = true;
        ObservableCollection<WeatherData> weatherList = new ObservableCollection<WeatherData>
        {
        };

        public ObservableCollection<WeatherData> weatherItems
        {
            get => weatherList;
        }

        public WeatherWindow()
        {
            InitializeComponent();
            this.Closing += WeatherWindow_Closing;
        }

        private void WeatherWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow mainWindow = this.Owner as MainWindow;
            mainWindow.lastCities = currentCities;
        }

        public WeatherWindow(List<string> cities)
        {
            InitializeComponent();
            foreach (string city in cities)
                addCityAsync(city);
        }

        private async void addCityAsync(string city)
        {
            string cityContent = await OpenWeatherContentGetter.getCityWeatherContentAsStringAsync(city);
            WeatherData weatherData = new WeatherData();
            string solution;

            if (parserChange)
            {
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(cityContent)))
                {
                    weatherData = OpenWeatherParser.parseXmlReader(stream);
                    solution = "StreamParser: ";
                }
            }
            else
            {
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(cityContent)))
                {
                    weatherData = OpenWeatherParser.parseLinq(stream);
                    solution = "Linq: ";
                }
            }

            weatherList.Add(new WeatherData()
            {
                city = solution + weatherData.city,
                temperature = (int)Math.Round(weatherData.temperature),
                wind = "Wind: " + weatherData.wind
            });

            parserChange = !parserChange;
        }

        public void updateWeatherWindowParameters(MainWindow parent)
        {
            this.Left = parent.Left;
            this.Top = parent.Top + parent.ActualHeight;
            this.Width = parent.ActualWidth;
            weatherWindowBorder.Width = parent.ActualWidth;
        }

        private void Mysz1(object sender, MouseEventArgs e)
        {
            Button button = sender as Button;
            button.Foreground = Brushes.Black;
        }

        private void Mysz2(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            Button button = sender as Button;

            button.Foreground = Brushes.White;
        }

        private void CityAddButton_Click(object sender, RoutedEventArgs e)
        {
            addCityAsync(cityTextBox.Text);
        }
    }
}

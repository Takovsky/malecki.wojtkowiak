﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace Lab01
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class WeatherWindow : Window
    {
        DatabaseWindow databaseWindow;
        public List<string> currentCities = new List<string>();
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
        }

        public void databaseWindowClosed()
        {
            databaseWindow = null;
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

            if (parserChange)
            {
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(cityContent)))
                {
                    weatherData = OpenWeatherParser.parseXmlReader(stream);
                }
            }
            else
            {
                using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(cityContent)))
                {
                    weatherData = OpenWeatherParser.parseLinq(stream);
                }
            }

            currentCities.Add(weatherData.city.Substring(weatherData.city.LastIndexOf(' ') + 1));
            weatherList.Add(weatherData);
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

        private void WeatherDatabaseButton_Click(object sender, RoutedEventArgs e)
        {
            if (databaseWindow != null)
                return;

            databaseWindow = new DatabaseWindow(this);
            databaseWindow.Show();
        }
    }
}

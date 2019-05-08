using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Diagnostics;

namespace Lab01
{
    /// <summary>
    /// Interaction logic for DatabaseWindow.xaml
    /// </summary>
    public partial class DatabaseWindow : Window
    {
        WeatherWindow parent;
        WeatherDatabaseEntities weatherDb = new WeatherDatabaseEntities();
        CollectionViewSource weatherEntryViewSource;
        CollectionViewSource weatherEntitiesViewSource;
        int Id = 10;

        public DatabaseWindow(WeatherWindow parent)
        {
            InitializeComponent();
            this.parent = parent;

            weatherEntryViewSource =
                    ( (CollectionViewSource)( this.FindResource("weatherEntryViewSource") ) );
            weatherEntitiesViewSource =
                    ( (CollectionViewSource)( this.FindResource("weatherEntitiesViewSource") ) );
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.databaseWindowClosed();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            weatherDb.Weathers.Local.Concat(weatherDb.Weathers.ToList());
            weatherEntryViewSource.Source = weatherDb.Weathers.Local;
            weatherEntitiesViewSource.Source = weatherDb.Weathers.Local;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var newEntry = new Weather() { Id = this.Id++, City = cityTextBox.Text, Temperature = float.Parse(temperatureTextBox.Text), Wind = windTextBox.Text };
            weatherDb.Weathers.Local.Add(newEntry);
            try
            {
                weatherDb.SaveChanges();
            }
            catch (Exception ex)
            {
                weatherDb.Weathers.Local.Remove(newEntry);
                Debug.WriteLine(ex);
            }
        }
    }
}

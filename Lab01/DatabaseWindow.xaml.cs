using System;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace Lab01
{
    /// <summary>
    /// Interaction logic for DatabaseWindow.xaml
    /// </summary>
    public partial class DatabaseWindow : Window
    {
        WeatherWindow parent;
        WeatherDatabaseEntities weatherDb;
        CollectionViewSource weatherEntryViewSource;
        CollectionViewSource weatherEntitiesViewSource;

        public DatabaseWindow(WeatherWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.weatherEntitiesViewSource = parent.weatherEntitiesViewSource;
            this.weatherEntryViewSource = parent.weatherEntryViewSource;
            this.weatherDb = parent.weatherDb;
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab01
{
    /// <summary>
    /// Interaction logic for DatabaseWindow.xaml
    /// </summary>
    public partial class DatabaseWindow : Window
    {
        WeatherWindow parent;
        public DatabaseWindow(WeatherWindow parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            parent.databaseWindowClosed();
        }
    }
}

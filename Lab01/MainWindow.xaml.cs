using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> people = new ObservableCollection<Person>
        { };

        public ObservableCollection<Person> Items
        {
            get => people;
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }



        private void AddNewPersonButton_Click(object sender, RoutedEventArgs e)
        {
            
            bool isNumeric = int.TryParse(ageTextBox.Text, out int n); // Czy wiek to liczba

            if ( !String.IsNullOrEmpty(ageTextBox.Text) && !String.IsNullOrEmpty( nameTextBox.Text) && (Obraz.Source != null )
                && (isNumeric==true))
            {
                people.Add(new Person { Age = int.Parse(ageTextBox.Text), Name = nameTextBox.Text, Image1 = new Image() { Source = Obraz.Source } });

                Obraz.Source = null;
                ageTextBox.Text = string.Empty;
                nameTextBox.Text = string.Empty;
            }
            else
            {
                string Error1 = "Dane niekompletne lub nieprawidłowe";
                MessageBox.Show(Error1);

                ageTextBox.Text = string.Empty;
                nameTextBox.Text = string.Empty;
                Obraz.Source = null;




            }
            
        }

        private void LoadPicture(object sender, RoutedEventArgs e)
        {
            String filepath = "";
            OpenFileDialog fileDialog = new OpenFileDialog() { Filter = " (*.jpg)|*.jpg| (*.jpeg)|*.jpeg| (*.gif)|*.gif| (*.png)|*.png| (*.pgm)|*.pgm"  };
            if (fileDialog.ShowDialog() == true)
            {
                filepath = fileDialog.FileName; // w stringu mamy sciezke

                Obraz.Source = new BitmapImage(new Uri(filepath)); // zmieniami sciezke wyswietlanego obrazka
            }
        }


        private void ShowData(object sender, MouseButtonEventArgs e)
        {

                var osoba = ListBox1.SelectedItem as Person;

            if (osoba != null)
            {

                Image2.Source = osoba.Image1.Source; 
                Tekst2.Text = "Age:   " + osoba.Age.ToString();
                Tekst1.Text = "Name:  " +  osoba.Name;
            }
            
        }


        private void Mysz1(object sender, MouseEventArgs e)
        {
            addNewPersonButton.Foreground = Brushes.Black;
            
        }



        private void Mysz2(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();

            addNewPersonButton.Foreground = Brushes.White;
        }



        private void Mysz33(object sender, MouseEventArgs e)
        {
            PhotoButton.Foreground = Brushes.Black;
        }



        private void Mysz44(object sender, MouseEventArgs e)
        {
            var bc = new BrushConverter();
            PhotoButton.Foreground = Brushes.White;
            

        }
    }
}
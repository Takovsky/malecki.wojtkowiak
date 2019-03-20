using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Lab01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Person> people = new ObservableCollection<Person>
        {
        };

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

            if (!String.IsNullOrEmpty(ageTextBox.Text) && !String.IsNullOrEmpty(nameTextBox.Text) && ( Obraz.Source != null )
                && ( isNumeric == true ))
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
            OpenFileDialog fileDialog = new OpenFileDialog() { Filter = " (*.jpg)|*.jpg| (*.jpeg)|*.jpeg| (*.gif)|*.gif| (*.png)|*.png| (*.pgm)|*.pgm" };
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
                Tekst1.Text = "Name:  " + osoba.Name;
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

        protected void timerValueTextBlockOffTimer(TextBox textBlock)
        {
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
            {
                textBlock.IsReadOnly = false;
                textBlock.Foreground = Brushes.Black;
                textBlock.Background = Brushes.White;
            });
            }
            catch { }
        }

        protected void timerValueTextBlockOnTimer(TextBox textBlock)
        {
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
            {
                textBlock.IsReadOnly = true;
                textBlock.Foreground = Brushes.Blue;
                textBlock.Background = Brushes.DarkGray;
            });
            }
            catch { }
        }

        protected void updateTimerValueTextBoxText(string text, TextBox textBlock)
        {
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    textBlock.Text = text;
                });
            }
            catch { }
        }

        class TimerCountdown
        {
            int mMs;
            int mCountdownBreak;
            MainWindow mSender;

            public TimerCountdown(MainWindow sender, int ms, int countdownBreak)
            {
                mSender = sender;
                mMs = ms;
                mCountdownBreak = countdownBreak;
            }

            public void updateStatus(Object stateInfo)
            {
                if (mMs < 0)
                {
                    mMs = 0;
                }
                mSender.updateTimerValueTextBoxText(mMs.ToString() + "ms", mSender.timerValueTextBox);
                mMs -= mCountdownBreak;
            }
        }

        async Task<int> countdownAsync(int ms, int countdownBreak)
        {
            int result = 0;
            while (result < ms)
            {
                result += countdownBreak;
                await Task.Delay(countdownBreak);
            }
            return ms;
        }

        private async void StartTimerButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(timerValueTextBox.Text, out int num))
            {
                MessageBox.Show("Not a number");
                return;
            }
            int ms = int.Parse(timerValueTextBox.Text);

            if (ms < 0)
            {
                MessageBox.Show("Not a positive number");
                return;
            }

            int countdownBreak = 10;
            timerValueTextBlockOnTimer(timerValueTextBox);
            var number = countdownAsync(ms, countdownBreak);
            System.Threading.Timer timer = new System.Threading.Timer(new TimerCountdown(this, ms, countdownBreak).updateStatus,
                null, TimeSpan.FromMilliseconds(0), TimeSpan.FromMilliseconds(countdownBreak));
            var result = await number;
            timer.Dispose();
            timerValueTextBlockOffTimer(timerValueTextBox);
        }
    }
}
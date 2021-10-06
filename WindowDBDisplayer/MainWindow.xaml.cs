using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace TestTaskWindowsApp
{
    public partial class MainWindow : Window //Наше Представление, большая часть логики которого в данном случае остаётся в XAML-е
    {
        public MainWindow()
        {
            DataContext = new CarPartsViewModel();
            InitializeComponent();
        }

        private void VencodeFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((CarPartsViewModel)DataContext).FilterVenCode(sender, e);
        }

        private void VencodeFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = string.Empty;
            textBox.Foreground = Brushes.Black;
        }

        private void VencodeFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Foreground = Brushes.LightSlateGray;
            textBox.Text = "фильтр по коду";
        }

        private void NameFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((CarPartsViewModel)DataContext).FilterPartName(sender, e); 
        }

        private void NameFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = string.Empty;
            textBox.Foreground = Brushes.Black;
        }

        private void NameFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Foreground = Brushes.LightSlateGray;
            textBox.Text = "фильтр по вхождению в текст имени";
        }

        private void LinkedNumberFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((CarPartsViewModel)DataContext).FilterLinkedNumber(sender, e);
        }

        private void LinkedNumberFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Text = string.Empty;
            textBox.Foreground = Brushes.Black;
        }

        private void LinkedNumberFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            textBox.Foreground = Brushes.LightSlateGray;
            textBox.Text = "фильтр по коду";
        }
    }
    
}

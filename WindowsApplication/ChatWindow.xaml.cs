using System.Windows;
using System.Windows.Media;

namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for StartSessionUserControl.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public ChatWindow()
        {
            InitializeComponent();
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            this.Hide();
            inputText.Text = "Hi, I'm looking for information on ...";
            inputText.Foreground = Brushes.LightGray;
        }

        private void inputText_GotFocus(object sender, RoutedEventArgs e)
        {
            inputText.Text = "";
            inputText.Foreground = Brushes.Black;
        }

        private void inputText_LostFocus(object sender, RoutedEventArgs e)
        {
            inputText.Text = "Hi, I'm looking for information on ...";
            inputText.Foreground = Brushes.LightGray;
        }
    }
}

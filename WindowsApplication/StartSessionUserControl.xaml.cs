using System.Windows;
using System.Windows.Media;
using WindowsApplication.ViewModules;

namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for StartSessionUserControl.xaml
    /// </summary>
    public partial class StartSessionUserControl : Window
    {
        string initialMessage = "Hi, I'm looking for information on ...";
        string question = "";
        StartSessionViewModel _model;
        ChatWindow chatWindow;

        public StartSessionUserControl()
        {
            InitializeComponent();
            _model = new StartSessionViewModel();
            DataContext = _model;
            chatWindow = new ChatWindow();
            chatWindow.Hide();
        }


        private void Start_Click(object sender, RoutedEventArgs e)
        {            
            chatWindow.Top = this.Top;
            chatWindow.Left = this.Left;
            chatWindow.question.Text = question;
            chatWindow.Show();
            this.Hide();
        }


        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            message.Text = "";
            message.Foreground = Brushes.Black;
        }

        private void message_LostFocus(object sender, RoutedEventArgs e)
        {
            question = message.Text;
            message.Text = initialMessage;
            message.Foreground = Brushes.LightGray;
        }
    }
}

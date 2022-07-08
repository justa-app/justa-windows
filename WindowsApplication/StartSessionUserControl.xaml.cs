using System.Windows;


namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for StartSessionUserControl.xaml
    /// </summary>
    public partial class StartSessionUserControl : Window
    {
        public StartSessionUserControl()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            ChatWindow chatWindow = new ChatWindow();
            chatWindow.Show();
            this.Hide();
        }
    }
}

using System.Threading;
using System.Windows;
using WindowsApplication.ViewModules;

namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for StartSessionUserControl.xaml
    /// </summary>
    public partial class StartSessionUserControl : Window
    {
        StartSessionViewModel _model;

        public StartSessionUserControl()
        {
            InitializeComponent();
            _model = new StartSessionViewModel();
            DataContext = _model;
            new Thread(_model.registerFocusChangeHandler).Start();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            ChatWindow chatWindow = new ChatWindow();
            chatWindow.Show();
            this.Hide();
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Grid_LostKeyboardFocus(object sender, System.Windows.Input.KeyboardFocusChangedEventArgs e)
        {
            this.Hide();
        }
    }
}

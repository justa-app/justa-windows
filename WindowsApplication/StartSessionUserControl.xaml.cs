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
        ChatWindow chatWindow;

        public StartSessionUserControl()
        {
            InitializeComponent();
            _model = new StartSessionViewModel();
            DataContext = _model;
            new Thread(_model.registerFocusChangeHandler).Start();
            chatWindow = new ChatWindow();
            chatWindow.Hide();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            new Thread(_model.unregisterFocusChangeHandler).Start();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            chatWindow.Top = this.Top;
            chatWindow.Left = this.Left;
            chatWindow.Show();
            this.Hide();
        }

        private void Window_LostFocus(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

    }
}

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for ExpertContent.xaml
    /// </summary>
    public partial class ExpertContent : UserControl
    {
        StartSessionUserControl startSessionControl;

        public ExpertContent()
        {
            InitializeComponent();
            startSessionControl = new StartSessionUserControl();
            startSessionControl.Hide();
        }

        private void StartSessionButton_Click(object sender, RoutedEventArgs e)
        {
            Window mainWindow = Application.Current.MainWindow;
            ((StackPanel)mainWindow.Content).Children.OfType<StackPanel>()
                .ToList()
                .ForEach(u => u.Visibility = Visibility.Hidden);
            startSessionControl.Top = mainWindow.Top;
            startSessionControl.Left = mainWindow.Left;
            startSessionControl.Show();
        }
    }
}

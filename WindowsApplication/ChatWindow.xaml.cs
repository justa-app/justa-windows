using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WindowsApplication.Helpers;

namespace WindowsApplication
{
    /// <summary>
    /// Interaction logic for StartSessionUserControl.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        string input = "";
        public ChatWindow()
        {
            InitializeComponent();
        }

        //private void Window_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    this.Hide();
        //    inputText.Text = "Hi, I'm looking for information on ...";
        //    inputText.Foreground = Brushes.LightGray;
        //}

        private void inputText_GotFocus(object sender, RoutedEventArgs e)
        {
            inputText.Text = "";
            inputText.Foreground = Brushes.Black;
        }

        private void inputText_LostFocus(object sender, RoutedEventArgs e)
        {
            input = inputText.Text;
            inputText.Text = "Hi, I'm looking for information on ...";
            inputText.Foreground = Brushes.LightGray;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var response = ApiHelper.postMessageAsync("138d3094-d390-4db8-92c8-ba9b6506b93d", "Lital", input);      //@TODO: expert and session should come from the start session window

            if (response.IsCompleted)       //@TODO: not awaiting for response
            {
                var rowDefinition = new RowDefinition();
                this.chatGrid.RowDefinitions.Add(rowDefinition);
                var rowCount = this.chatGrid.RowDefinitions.Count;

                var textBlock = new TextBlock();
                textBlock.Margin = new Thickness(70, 10, 10, 10);
                textBlock.Padding = new Thickness(6, 6, 6, 6);
                textBlock.Foreground = Brushes.White;
                textBlock.Background = Brushes.LightBlue;
                textBlock.Text = input;
                textBlock.HorizontalAlignment = HorizontalAlignment.Right;
                textBlock.TextWrapping = TextWrapping.WrapWithOverflow;
                textBlock.SetValue(Grid.RowProperty, rowCount - 1);       //@TODO: not shown in the scrollViewer         
            }
        }
    }
}

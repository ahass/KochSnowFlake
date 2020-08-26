using System.Windows;
using System.Windows.Controls;
using KochSnowFlake.ViewModels;

namespace KochSnowFlake
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel();

            InitializeComponent();

            CenterWindowOnScreen();
        }

        private void CenterWindowOnScreen()
        {
            var screenWidth = SystemParameters.PrimaryScreenWidth;
            var screenHeight = SystemParameters.PrimaryScreenHeight;
            var windowWidth = Width;
            var windowHeight = Height;
            Left = screenWidth / 2 - windowWidth / 2;
            Top = screenHeight / 2 - windowHeight / 2;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox) sender;

            textBox.CaptureMouse();
        }

        private void TextBox_GotMouseCapture(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox) sender;

            textBox.SelectAll();
        }

        private void TextBox_OnIsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            var textBox = (TextBox) sender;

            textBox.SelectAll();
        }
    }
}
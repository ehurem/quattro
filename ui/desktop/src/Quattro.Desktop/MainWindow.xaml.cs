using System.Windows;

namespace Quattro.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new WindowViewModel(this);
        }

        private void ButtonPopupLogout_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonOpenMenu_OnClick(object sender, RoutedEventArgs e)
        {
            //ButtonOpenMenu.Visibility = Visibility.Collapsed;
            //ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_OnClick(object sender, RoutedEventArgs e)
        {
            //ButtonOpenMenu.Visibility = Visibility.Visible;
            //ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }
    }
}

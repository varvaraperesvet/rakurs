using System.Windows;

namespace wpftest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Chart.DataContext = new ChartViewModel();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ((ChartViewModel)Chart.DataContext).Refresh();
        }
    }
}
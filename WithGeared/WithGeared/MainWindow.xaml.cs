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

namespace WithGeared
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IDisposable
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Dispose()
        {
            var vm = (MainWindowVM)DataContext;
            for (var index = 0; index < vm.Series.Count; index++)
            {
                var series = vm.Series[index];
                var disposable = series.Values as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }

            vm.Series = null;
        }
    }
}

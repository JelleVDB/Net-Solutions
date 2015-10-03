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

namespace oefTeller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public Boolean IsMultiThreaded
        {
            get { return chkThreaded.IsChecked.Value; }
        }

        private void btnTel1_Click(object sender, RoutedEventArgs e)
        {
            Teller1Starten();
        }

        private void btnTel2_Click(object sender, RoutedEventArgs e)
        {
            Teller2Starten();
        }

        private void Teller1Starten()
        {
            txtTel1.StartTeller(IsMultiThreaded);
        }

        private void Teller2Starten()
        {
            txtTel2.StartTeller(IsMultiThreaded);
        }
    }
}

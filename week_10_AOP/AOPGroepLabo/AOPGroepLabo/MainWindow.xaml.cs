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

namespace AOPGroepLabo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            BtnStart.Click += BtnStart_Click;
            BtnDump.Click += (s, e) => EntryTellerAttribute.DumpInfo();
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            TestAOP();
        }

        private void TestAOP()
        {
            Wiskundige ivo = new Wiskundige();
            int n = 0;
            if(int.TryParse(txtN.Text, out n))
            {
                int f = ivo.Fibonacci(n);
                txtF.Text = "" + f;
            }
        }

    }
}

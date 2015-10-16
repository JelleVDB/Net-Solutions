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

namespace QueenBord
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            grdGrid.Children.Add(grdBord);
            Grid.SetRow(grdBord, 1);
            Grid.SetColumnSpan(grdBord, 2);

            grdBord.maakBord(Convert.ToInt32(sudQueens.Value));

            sudQueens.ValueChanged += SudQueens_ValueChanged;
        }

        private void SudQueens_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            grdBord.maakBord(Convert.ToInt32(sudQueens.Value));
            
        }
    }
}

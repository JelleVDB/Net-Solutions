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

namespace AOPValidatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnDatumValidate.Click += BtnDatumValidate_Click;
            btnRekeningValidate.Click += BtnRekeningValidate_Click;
        }

        /* --- GEBOORTEJAAR ---*/
        private void BtnDatumValidate_Click(object sender, RoutedEventArgs e)
        {
            int value;
            if (!int.TryParse(txtGeboortejaar.Text, out value))
                return;
            try
            {
                txtRangeValidation.Text = CheckOnderBovenGrens(value);
            }catch(AOPException ex)
            {
                txtRangeValidation.Text = ex.Message;
            }
        }

        [AOPOnderBovengrens]
        public static string CheckOnderBovenGrens([OnderBovengrens(1900)] int getal)
        {
            return "Geboortejaar OK!";
        }


        /* --- REKENINGNUMMER ---*/
        //xxx-xxxxxx-xx
        private void BtnRekeningValidate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (AOPException ex)
            {
                txtExpressionValidation.Text = ex.Message;
            }
        }
    }
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

namespace XMLReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnOpenFile.Click += BtnOpenFile_Click;
            btnPlumb.Click += BtnPlumb_Click;
        }

        private void BtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            findXML();
        }

        private void BtnPlumb_Click(object sender, RoutedEventArgs e)
        {
            xmlViewer.ToonKleur = new toonKleurDelegate(berekenKleur);
        }

        private void findXML()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Open XML Document";
            ofd.Filter = "XML-files (*.xml)|*.xml";
            ofd.InitialDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
            if (ofd.ShowDialog().Value)
            {
                xmlViewer.searchXML(ofd.FileName);
                txtXMLFile.Text = ofd.FileName;
            }
        }

        private TreeNode berekenKleur(TreeNode node)
        {
            node.Foreground = Brushes.Black;
            switch (node.niveau)
            {
                case 0:
                    node.Foreground = Brushes.SlateGray;
                    break;
                case 1:
                    node.Foreground = Brushes.Blue;
                    break;
                case 2:
                    node.Foreground = Brushes.Red;
                    break;
                case 3:
                    node.Foreground = Brushes.Green;
                    break;
                default:
                    node.Foreground = Brushes.Black;
                    break;
            }
            return node;
        }
    }
}

using CustomAttribute;
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
using System.Windows.Shapes;

namespace reflection_plugins
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] fileFilters = new string[] { "*.exe", "*.dll" };

        public MainWindow()
        {
            InitializeComponent();
            loadAssemblies();
        }

        private void getFiles(string path, string filter, List<string> files)
        {
            foreach (string file in Directory.GetFiles(path, filter))
            {
                files.Add(file);
            }
        }

        private List<string> loadPlugins()
        {
            List<string> files = new List<string>();
            foreach (string filter in fileFilters)
            {
                getFiles(AppDomain.CurrentDomain.BaseDirectory + @"plugins", filter, files);
            }
            return files;
        }

        private void loadAssemblies()
        {

            List<string> pluginFiles = loadPlugins();

            foreach (string file in pluginFiles)
            {
                Assembly ass = Assembly.LoadFile(file);
                foreach (Type t in ass.GetTypes())
                {
                    CheckAssemblyAttributes(t);
                }
            }
        }

        private void CheckAssemblyAttributes(Type t)
        {
            foreach (Attribute a in t.GetCustomAttributes())
            {
                if (a.GetType().Equals(typeof(PluginAttribute)))
                {
                    PluginAttribute pa = a as PluginAttribute;
                    if (pa.IsPlugin)
                    {
                        PluginItem pi = new PluginItem(pa.Name, t);
                        menu.Items.Add(pi);
                    }

                }

            }
        }
    }
}

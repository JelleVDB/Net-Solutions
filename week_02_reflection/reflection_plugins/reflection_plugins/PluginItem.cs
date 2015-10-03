using CustomAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace reflection_plugins
{
    class PluginItem : MenuItem
    {
        Type type;

        public PluginItem(string header, Type t)
        {
            Header = header;
            type = t;
            Click += PluginItem_Click;
        }

        private void PluginItem_Click(object sender, RoutedEventArgs e)
        {
            Window wdw = (Window)Activator.CreateInstance(type);
            wdw.Show();
        }
    }
}

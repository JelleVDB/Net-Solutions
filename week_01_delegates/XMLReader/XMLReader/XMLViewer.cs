using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml;

namespace XMLReader
{
    public class XMLViewer : TreeView
    {
        public void searchXML(string path)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            berekenNodes(xDoc);
        }

        private void berekenNodes(XmlDocument xDoc)
        {
            TreeNode node = new TreeNode();
            node.ToonKleur = ToonKleur;
            this.Items.Clear();
            this.Items.Add(node.bouwBoom(xDoc));
        }

        private toonKleurDelegate _toonKleur;
        public toonKleurDelegate ToonKleur
        {
            get { return _toonKleur; }
            set { _toonKleur = value; }
        }
    }
}

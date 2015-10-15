using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace XMLReader
{
    public delegate TreeNode toonTekstDelegate(XmlDocument doc);
    public delegate TreeNode toonKleurDelegate(TreeNode node);
    public class TreeNode : TreeViewItem
    {
        private toonKleurDelegate _toonKleur;
        public int niveau = -1;

        public toonKleurDelegate ToonKleur
        {
            get { return _toonKleur; }
            set { _toonKleur = value; }
        }

        public TreeNode()
        {
            _toonKleur = new toonKleurDelegate(berekenKleur);
        }

        public TreeNode bouwBoom(XmlDocument doc)
        {
            return berekenSubNodes(doc);
        }

        private TreeNode berekenSubNodes(XmlDocument doc)
        {
            TreeNode node = new TreeNode();
            node.IsExpanded = true;
            node.Header = doc.DocumentElement.Name;
            foreach(XmlNode xmlnode in doc.DocumentElement)
            {
                node.AddChild(maakNode(xmlnode, niveau + 1));
            }
            node.niveau = niveau + 1;

            return node;
        }

        private object maakNode(XmlNode xmlnode, int niv)
        {
            int niveau = niv + 1;
            TreeNode node = new TreeNode();
            node.IsExpanded = true;
            string attribute = "";
            foreach(XmlNode n in xmlnode.Attributes)
            {
                attribute += " " + n.Name + ": " + n.InnerText;
            }
            node.Header = xmlnode.Name + attribute;
            foreach(XmlNode n in xmlnode.ChildNodes)
            {
                if(n.NodeType.ToString() != "Text")
                {
                    node.AddChild(maakNode(n, niveau));
                }
            }
            node.niveau = niveau;
            if(ToonKleur != null)
            {
                node = ToonKleur(node);
            }
            else
            {
                node = berekenKleur(node);
            }

            return node;
        }

        public TreeNode startdeligateToonKleur(TreeNode node)
        {
            return ToonKleur.Invoke(node);
        }

        private TreeNode berekenKleur(TreeNode node)
        {
            node.Foreground = Brushes.Black;
            return node;
        }
    }
}

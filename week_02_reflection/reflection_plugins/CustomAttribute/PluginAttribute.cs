using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; set; }
        public bool IsPlugin { get; set; }

        public PluginAttribute(string Name, string Description, bool IsPlugin)
        {
            this.Name = Name;
            this.Description = Description;
            this.IsPlugin = IsPlugin;
        }
    }
}

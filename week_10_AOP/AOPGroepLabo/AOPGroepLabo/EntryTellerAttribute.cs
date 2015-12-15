using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostSharp.Aspects;

namespace AOPGroepLabo
{
    [Serializable]
    public class EntryTellerAttribute : PostSharp.Aspects.OnMethodBoundaryAspect
    {
        private static Dictionary<string, int> _teldict = new Dictionary<string, int>();
        public override void OnEntry(MethodExecutionArgs args)
        {
            base.OnEntry(args);

            string methodfullname = args.Method.DeclaringType.FullName + "." + args.Method.Name;

            if(_teldict.Keys.Contains(methodfullname))
            {
                int already = _teldict[methodfullname];
                _teldict.Remove(methodfullname);
                already += 1;
                _teldict.Add(methodfullname, already);
            }
            else
            {
                _teldict.Add(methodfullname, 1);
            }
        }

        public static void DumpInfo()
        {
            foreach(string k in _teldict.Keys)
            {
                int t = _teldict[k];
                Console.WriteLine(k + " - " + t);
            }
        }
    }
}

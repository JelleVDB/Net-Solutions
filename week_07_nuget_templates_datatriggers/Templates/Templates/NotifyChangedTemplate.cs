using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    class NotifyChangedTemplate : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

/*
HOE EIGEN TEMPLATE MAKEN
------------------------

C:\Program Files (x86)\Microsoft Visual Studio 14.0\Common7\IDE\ItemTemplates\CSharp
Maak map aan met daarin gewenste template
na afloop, run CMD als admin en navigeer naar de devenv.exe file (in map IDE)
run devenv.exe /installvstemplates
*/

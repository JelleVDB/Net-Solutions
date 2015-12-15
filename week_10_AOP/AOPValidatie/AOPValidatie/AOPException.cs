using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPValidatie
{
    public class AOPException : Exception
    {
        private string _message;

        public AOPException(string message)
        {
            this._message = message;
        }

        public override string Message
        {
            get
            {
                return _message;
            }
        }
    }
}

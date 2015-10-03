using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace oefTeller
{
    public class CustomTextVak : TextBox
    {
        public int _teller = 0;
        public delegate void startTellen();

        public CustomTextVak()
        {
            
        }
        
        public void StartTeller(Boolean threaded)
        {
            startTellen routine = new startTellen(incrementTeller);
            if (threaded) routine.BeginInvoke(null, null); //begin operatie, pas uitvoeren als deze klaar is
            else routine.Invoke();
        }

        private void ToonTekst()
        {
            this.Text = _teller.ToString();
        }

        private void incrementTeller()
        {
            while(true)
            {
                if (_teller <= 1000)
                {
                    _teller++;
                    Dispatcher.Invoke(ToonTekst);
                }
                else _teller = 0;

                Thread.Sleep(10);
            }
        }
    }
}

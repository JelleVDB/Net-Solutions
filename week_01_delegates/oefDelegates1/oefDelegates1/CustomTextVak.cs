using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace oefDelegates1
{
    public delegate void OnEmpty(object sender, EventArgs e); //delegate voor het event
    public class CustomTextVak : TextBox
    {
        public event OnEmpty TextVakIsLeeg; //eventdefinitie
        public CustomTextVak()
        {
            this.TextChanged += new TextChangedEventHandler(CustomTextVak_TextChanged);
        }

        void CustomTextVak_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.Text.Length == 0) //als textvak leeg is
                if(TextVakIsLeeg != null) //minstens 1 client voor dit event nodig, anders null
                    TextVakIsLeeg.Invoke(sender, EventArgs.Empty); //starten van het event
        }
    }
}

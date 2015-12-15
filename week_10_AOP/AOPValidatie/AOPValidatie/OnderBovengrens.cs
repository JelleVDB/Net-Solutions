using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOPValidatie
{
    public class OnderBovengrens : Attribute, IAOPValidate
    {
        private int _onderGrens;
        private int _bovenGrens;

        public OnderBovengrens(int onderGrens)
        {
            this._onderGrens = onderGrens;
            this._bovenGrens = DateTime.Now.Year;
        }

        public void Validate(object arg)
        {
            int value = (int)arg;
            if (value < _onderGrens)
                throw new AOPException(value + " is kleiner dan " + _onderGrens + ".");
            if(value > _bovenGrens)
                throw new AOPException(value + " is groter dan " + _bovenGrens + ".");
        }
    }
}

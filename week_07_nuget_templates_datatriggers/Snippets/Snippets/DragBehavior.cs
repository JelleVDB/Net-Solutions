using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snippets
{
    public class DragBehavior
    {
        /*propachanged*/
        private UIElement _uie = null;

        public static Boolean GetMyMethod(DependencyObject obj)
        {
            return (Boolean)obj.GetValue(DragBehavior.MyMethod);
         }

        public static void SetMyMethod(DependencyObject obj, Boolean value)
        {
            obj.SetValue(DragBehavior.MyMethod, value);
        }

        public static readonly DependencyProperty MyMethod = DependencyProperty.RegisterAttached("MyMethod", typeof(Boolean), typeof(DragBehavior),
           new UIPropertyMetadata(new PropertyChangedCallback(MyMethodCb)));

        private static void MyMethodCb(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {

        }


        /*propn*/
        string myProperty;
        public string MyProperty
        {
            get
            {
                return myProperty;
            }
            set
            {
                if (myProperty != value)
                {
                    myProperty = value;
                    RaisePropertyChanged("MyProperty");
                }
            }
        }


        /*raisepc*/
        void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
        public event PropertyChangedEventHandler PropertyChanged;



    }
}

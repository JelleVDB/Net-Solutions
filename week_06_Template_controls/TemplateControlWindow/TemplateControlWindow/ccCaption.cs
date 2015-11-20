using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TemplateControlWindow
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TemplateControlWindow"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TemplateControlWindow;assembly=TemplateControlWindow"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:ccCaption/>
    ///
    /// </summary>
    /// 

    [TemplatePart(Name = "PART_title", Type = typeof(UIElement))]
    [TemplatePart(Name = "PART_minimize", Type = typeof(UIElement))]
    [TemplatePart(Name = "PART_maximize", Type = typeof(UIElement))]
    [TemplatePart(Name = "PART_close", Type = typeof(UIElement))]

    public class ccCaption : Control
    {

        static ccCaption()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ccCaption), new FrameworkPropertyMetadata(typeof(ccCaption)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            UIElement doMinimize = GetTemplateChild("PART_minimize") as UIElement;
            UIElement doMaximize = GetTemplateChild("PART_maximize") as UIElement;
            UIElement doClose = GetTemplateChild("PART_close") as UIElement;

            if (doMinimize != null)
            {
                //doMinimize.MouseUp += DoMinimize_MouseUp;
                doMinimize.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(DoMinimize_MouseUp), true);
            }
            if(doMaximize != null)
            {
                //doMaximize.MouseUp += DoMaximize_MouseUp;
                doMaximize.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(DoMaximize_MouseUp), true);
            }
            if(doClose != null)
            {
                //doClose.MouseUp += DoClose_MouseUp;
                doClose.AddHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(DoClose_MouseUp), true);
            }
        }

        
        private void DoMinimize_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).WindowState = WindowState.Minimized;
        }

        private void DoMaximize_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(Window.GetWindow(this).WindowState == WindowState.Normal)
            {
                Window.GetWindow(this).WindowState = WindowState.Maximized;
            }
            else
            {
                Window.GetWindow(this).WindowState = WindowState.Normal;
            }
            
        }

        private void DoClose_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window.GetWindow(this).Close();
        }
    }
}

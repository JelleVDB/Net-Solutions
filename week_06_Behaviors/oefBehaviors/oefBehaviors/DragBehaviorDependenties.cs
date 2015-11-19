using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace oefBehaviors
{
    class DragBehaviorDependenties
    {
        private Point _elementStartPosition;
        private Point _mouseStartPosition;
        private TranslateTransform _tt = new TranslateTransform();
        private UIElement _uie = null;
        private Window _parent = null;



        public static Boolean GetIsDragable(DependencyObject obj)
        {
            return (Boolean)obj.GetValue(DragBehaviorDependenties.IsDraggable);
        }

        public static void SetIsDragable(DependencyObject obj, Boolean value)
        {
            obj.SetValue(DragBehaviorDependenties.IsDraggable, value);
        }


        public static readonly DependencyProperty IsDraggable = DependencyProperty.RegisterAttached("IsDraggable", typeof(Boolean), typeof(DragBehaviorDependenties),
            new UIPropertyMetadata(new PropertyChangedCallback(DragEnabledCb)));


        private static void DragEnabledCb(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            UIElement element = target as UIElement;

            if (element == null) return;
            var behavior = new DragBehaviorDependenties()
            {
                _uie = element
            };

            if (behavior == null) return;
            if((bool) e.NewValue)
            {
                behavior.OnEnabled(element);
            }
            else
            {
                behavior.OnDisabling(element);
            }
        }

        public void OnEnabled(UIElement dependencyObject)
        {
            _parent = Application.Current.MainWindow;
            _uie.RenderTransform = _tt;
            /*_uie.MouseLeftButtonDown += _uie_MouseLeftButtonDown;
            _uie.MouseLeftButtonUp += _uie_MouseLeftButtonUp;
            _uie.MouseMove += _uie_MouseMove;*/

            _uie.AddHandler(UIElement.MouseLeftButtonDownEvent, new MouseButtonEventHandler(_uie_MouseLeftButtonDown), true);
            _uie.AddHandler(UIElement.MouseMoveEvent, new MouseEventHandler(_uie_MouseMove), true);
            _uie.AddHandler(UIElement.MouseLeftButtonUpEvent, new MouseButtonEventHandler(_uie_MouseLeftButtonUp), true);
        }

        public void OnDisabling(UIElement dependencyObject)
        {
            /*_uie.MouseLeftButtonDown -= _uie_MouseLeftButtonDown;
            _uie.MouseLeftButtonUp -= _uie_MouseLeftButtonUp;
            _uie.MouseMove -= _uie_MouseMove;*/

            _uie.RemoveHandler(UIElement.MouseLeftButtonDownEvent, null);
            _uie.RemoveHandler(UIElement.MouseMoveEvent, null);
            _uie.RemoveHandler(UIElement.MouseLeftButtonUpEvent, null);

            _tt = null;
        }

        private void _uie_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _elementStartPosition = _uie.TranslatePoint(new Point(), _parent);
            _mouseStartPosition = e.GetPosition(_parent);
            _uie.CaptureMouse();
        }

        private void _uie_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var positionDifference = e.GetPosition(_parent) - _mouseStartPosition;

            if (_uie.IsMouseCaptured)
            {
                _tt.X = _elementStartPosition.X + positionDifference.X;
                _tt.Y = _elementStartPosition.Y + positionDifference.Y;
            }
        }

        private void _uie_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            _uie.ReleaseMouseCapture();
        }

        

        
    }
}

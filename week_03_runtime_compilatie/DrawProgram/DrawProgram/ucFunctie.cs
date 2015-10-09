using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawProgram
{
    class ucFunctie : System.Windows.Controls.Canvas
    {
        public ucFunctie()
        {
            this.Loaded += UcFunctie_Loaded;
            this.SizeChanged += UcFunctie_SizeChanged;
        }

        private void UcFunctie_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            drawFunction();
        }

        private void UcFunctie_Loaded(object sender, RoutedEventArgs e)
        {
            drawFunction();
        }

        private void drawFunction()
        {
            Children.Clear();
            Point[] points = new Point[(int)ActualWidth];
            points = calculatePointValuesFromFunction(points, tekenFunctie.drawFunction);

            for (int i = 0; i < points.Length - 1; i++)
            {
                Line line = new Line();
                line.X1 = points[i].X;
                line.X2 = points[i + 1].X;
                line.Y1 = points[i].Y;
                line.Y2 = points[i + 1].Y;
                line.Stroke = Brushes.Red;
                line.StrokeThickness = 2;
                Children.Add(line);
            }
        }

        private Point[] calculatePointValuesFromFunction(Point[] points, Func<double, double> drawFunction)
        {
            double deltaX = 2 * System.Math.PI / ActualWidth;

            for(int i = 0; i< points.Length; i++)
            {
                points[i].Y = drawFunction(i * deltaX);
            }

            double minY = points.Min(p => p.Y);
            double maxY = points.Max(p => p.Y);

            double deltaY = maxY - minY;
            double yScale = ActualHeight / deltaY;

            for(int i = 0; i<points.Length; i++)
            {
                points[i].X = i;
                points[i].Y = (maxY - points[i].Y) / (deltaY / ActualHeight);
            }

            return points;
        }
    }
}

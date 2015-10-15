using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DrawProgram
{
    class ucFunctie : System.Windows.Controls.Canvas
    {
        public void drawFunction(string function)
        {
            Children.Clear();
            Point[] points = getPointsFromFunction(function);

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

        private Point[] getPointsFromFunction(string function)
        {
            Assembly functionAss = compileFunctionClass(function);
            dynamic functionObject = functionAss.CreateInstance("DrawProgram.Function");
            Type functionClass = functionAss.GetType("DrawProgram.Function");

            Point[] points = new Point[(int)ActualWidth];
            points = calculatePointValuesFromFunction(points, functionObject);

            return points;
        }

        private Assembly compileFunctionClass(string function)
        {
            string csharpCode = @"namespace DrawProgram
                                  { public class Function
                                    {
                                        public double RunFunction(double x)
                                        {return " + function + @";
                                        }}}";
            CompilerParameters cparams = new CompilerParameters();
            cparams.GenerateInMemory = true;

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerResults results = provider.CompileAssemblyFromSource(cparams, csharpCode);
            return results.CompiledAssembly;
        }

        private Point[] calculatePointValuesFromFunction(Point[] points, dynamic functionObject)
        {
            double deltaX = 5 * System.Math.PI / ActualWidth;

            for(int i = 0; i< points.Length; i++)
            {
                points[i].Y = functionObject.RunFunction(i * deltaX);
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

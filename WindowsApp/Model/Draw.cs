using IntersectionLibrary;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;

namespace WindowsApp.Model
{
    public static class Draw
    {
        public static Ellipse DrawPoint(List<double> args)
        {
            int radius = 5;
            Ellipse circle = new Ellipse { Width = 2 * radius, Height = 2 * radius };
            circle.Fill = new SolidColorBrush(Windows.UI.Colors.Black);
            circle.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
            circle.StrokeThickness = 2;
            double left = args[0] - radius;
            double top = args[1] - radius;
            circle.Margin = new Thickness(left, top, 0, 0);

            return circle;
        }

        public static Line DrawLineSegment(List<double> args)
        {
            var line = new Line();
            line.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
            line.StrokeThickness = 2;
            line.X1 = args[0];
            line.Y1 = args[1];
            line.X2 = args[2];
            line.Y2 = args[3];

            return line;
        }

        public static Line DrawRayLine(List<double> args)
        {
            // todo: need to modify args for drawing ray line.
            return DrawLineSegment(args);
        }

        public static Line DrawStraightLine(List<double> args)
        {
            // todo: need to modify args for drawing straight line.
            return DrawLineSegment(args);
        }

        public static Ellipse DrawCircle(List<double> args)
        {
            Ellipse circle = new Ellipse { Width = 2 * args[2], Height = 2 * args[2] };
            circle.Stroke = new SolidColorBrush(Windows.UI.Colors.Black);
            circle.StrokeThickness = 2;
            double left = args[0] - args[2];
            double top = args[1] - args[2];
            circle.Margin = new Thickness(left, top, 0, 0);

            return circle;
        }


        public static Shape DrawObject(SimpleObject o)
        {
            Shape drawObj;
           
            if (o is IntersectionLibrary.LineSegment)
            {
                drawObj = DrawLineSegment(o.args);
            }
            else if (o is RayLine)
            {
                drawObj = DrawRayLine(o.args);
            }
            else if (o is StraightLine)
            {
                drawObj = DrawStraightLine(o.args);
            }
            else
            {
                drawObj = DrawCircle(o.args);
            }
            
            return drawObj;
        }
    }
}

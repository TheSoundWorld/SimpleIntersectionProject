using System;
using System.Collections.Generic;
using System.Linq;

namespace IntersectionLibrary
{
    public abstract class SimpleObject
    {
        // Store the coefficients describing a geometric object.
        public List<double> args; 


        public SimpleObject(List<double> args)
        {
            this.args = args;
        }


        // Compute the intersection points between two geometric objects.
        public abstract List<double> Intersect(SimpleObject obj);


        // Compute the intersectino points between two straight lines.
        public static List<double> LineLineIntersect(List<double> l1, List<double> l2)
        {
            // todo: need to check args.
            double x1 = l1[0];
            double y1 = l1[1];
            double x2 = l1[2];
            double y2 = l1[3];
            double x3 = l2[0];
            double y3 = l2[1];
            double x4 = l2[2];
            double y4 = l2[3];

            double denominator = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);

            List<double> intersection = new List<double>();

            if (denominator != 0)
            {
                double px = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / denominator;
                double py = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / denominator;
                intersection.Add(px);
                intersection.Add(py);
            }
            else
            {
                if ((x1 - x3) * (y3 - y2) - (y1 - y3) * (x3 - x2) == 0)
                {
                    throw new IntersectionsInfiniteException();
                }
            }

            return intersection;
        }


        // Compute the intersectino points between a straight line and a circle.
        public static List<double> LineCircleIntersect(List<double> line, List<double> circle)
        {
            // todo: need to check args.
            double x1 = line[0];
            double y1 = line[1];
            double x2 = line[2];
            double y2 = line[3];
            double x = circle[0];
            double y = circle[1];
            double r = circle[2];

            x1 -= x;
            y1 -= y;
            x2 -= x;
            y2 -= y;

            double a = y2 - y1;
            double b = x1 - x2;
            double c = x1 * y2 - x2 * y1;

            double delta = r * r * (a * a + b * b) - c * c;

            List<double> intersection = new List<double>();

            if (delta == 0)
            {
                x = a * c / (a * a + b * b) + circle[0];
                y = b * c / (a * a + b * b) + circle[1];
                intersection.Add(x);
                intersection.Add(y);
            }
            else if (delta > 0)
            {
                x1 = (a * c + b * Math.Sqrt(delta)) / (a * a + b * b) + circle[0];
                x2 = (a * c - b * Math.Sqrt(delta)) / (a * a + b * b) + circle[0];
                y1 = (b * c - a * Math.Sqrt(delta)) / (a * a + b * b) + circle[1];
                y2 = (b * c + a * Math.Sqrt(delta)) / (a * a + b * b) + circle[1];
                intersection.Add(x1);
                intersection.Add(y1);
                intersection.Add(x2);
                intersection.Add(y2);
            }
            return intersection;
        }


        // Compute the intersectino points between two circles.
        public static List<double> CircleCircleIntersect(List<double> c1, List<double> c2)
        {
            // todo: need to check args.
            double x1 = c1[0];
            double y1 = c1[1];
            double r1 = c1[2];
            double x2 = c2[0];
            double y2 = c2[1];
            double r2 = c2[2];

            if (x1 == x2 && y1 == y2 && r1 == r2)
            {
                
                    throw new IntersectionsInfiniteException();

               
            }

            double a = 2 * (x2 - x1);
            double b = 2 * (y2 - y1);
            double c = r1 * r1 - x1 * x1 - y1 * y1 - r2 * r2 + x2 * x2 + y2 * y2;

            double d = Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2));
            if (d > r1 + r2 || d < Math.Abs(r1 - r2))
            {
                List<double> intersection = new List<double>();
                return intersection;
            }

            List<double> line = new List<double>();
            if (a == 0)
            {
                line.Add(0);
                line.Add(c / b);
                line.Add(1);
                line.Add(c / b);
            }
            else if (b == 0)
            {
                line.Add(c / a);
                line.Add(1);
                line.Add(c / a);
                line.Add(0);
            }
            else
            {
                line.Add(0);
                line.Add(c / b);
                line.Add(c / a);
                line.Add(0);
            }
            return LineCircleIntersect(line, c1);
        }

        // Compute the dot between two vectors.
        // Point1(x1, x2), Point2(x3, x4), Vector1(Point1, Point2)
        // Point3(x5, x6), Point4(x7, x8), Vector1(Point3, Point4)
        public double Dot(double x1, double x2, double x3, double x4,
                          double x5, double x6, double x7, double x8)
        {
            double v1x = x1 - x3;
            double v1y = x2 - x4;
            double v2x = x5 - x7;
            double v2y = x6 - x8;
            return v1x * v2x + v1y * v2y;
        }
    }

    // Represents the straight line object.
    public class StraightLine : SimpleObject
    {
        public StraightLine(List<double> args) : base(args) { }


        public override List<double> Intersect(SimpleObject obj)
        {
            
                if (obj is StraightLine)
                {
                    return LineLineIntersect(this.args, obj.args);
                }
                else if (obj is Circle)
                {
                    return LineCircleIntersect(this.args, obj.args);
                }
                else if (obj is RayLine)
                {
                    List<double> intersection = LineLineIntersect(this.args, obj.args);

                    // Need to check if the intersection points is on the ray line.
                    if (intersection.Count >= 2 &&
                        Dot(obj.args[0], obj.args[1], obj.args[2], obj.args[3],
                            obj.args[0], obj.args[1], intersection[0], intersection[1]) < 0)
                    {
                        intersection.Clear();
                    }
                    return intersection;
                }
                else
                {
                    List<double> intersection = LineLineIntersect(this.args, obj.args);

                    // Need to check if the intersection points is on the line segment.
                    if (intersection.Count >=2 && 
                        Dot(intersection[0], intersection[1], obj.args[0], obj.args[1],
                            intersection[0], intersection[1], obj.args[2], obj.args[3]) > 0)
                    {
                        intersection.Clear();
                    }
                    return intersection;
                }
           

        }
    }


    public class RayLine : SimpleObject
    {
        public RayLine(List<double> args) : base(args) { }


        public override List<double> Intersect(SimpleObject obj)
        {
            
                if (obj is StraightLine)
                {
                    return ((StraightLine)obj).Intersect(this);
                }
                else if (obj is RayLine)
                {
                    List<double> intersection = LineLineIntersect(this.args, obj.args);
                    if (intersection.Count >= 2 &&
                        (Dot(obj.args[0], obj.args[1], obj.args[2], obj.args[3],
                            obj.args[0], obj.args[1], intersection[0], intersection[1]) < 0 ||
                        Dot(this.args[0], this.args[1], this.args[2], this.args[3],
                            this.args[0], this.args[1], intersection[0], intersection[1]) < 0))
                    {
                        intersection.Clear();
                    }
                    return intersection;
                }
                else if (obj is LineSegment)
                {
                    List<double> intersection = LineLineIntersect(this.args, obj.args);
                    if (intersection.Count >= 2 &&
                        (Dot(intersection[0], intersection[1], obj.args[0], obj.args[1],
                            intersection[0], intersection[1], obj.args[2], obj.args[3]) > 0 ||
                        Dot(this.args[0], this.args[1], this.args[2], this.args[3],
                            this.args[0], this.args[1], intersection[0], intersection[1]) < 0))
                    {
                        intersection.Clear();
                    }
                    return intersection;
                }
                else
                {
                    List<double> intersection = LineCircleIntersect(this.args, obj.args);

                    if (intersection.Count >= 4 &&
                        Dot(this.args[0], this.args[1], this.args[2], this.args[3],
                            this.args[0], this.args[1], intersection[2], intersection[3]) < 0)
                    {
                        intersection.RemoveRange(2, 2);
                    }

                    if (intersection.Count >= 2 &&
                        Dot(this.args[0], this.args[1], this.args[2], this.args[3],
                            this.args[0], this.args[1], intersection[0], intersection[1]) < 0)
                    {
                        intersection.RemoveRange(0, 2);
                    }

                    return intersection;
                }
           
        }
    }


    public class LineSegment : SimpleObject
    {
        public LineSegment(List<double> args) : base(args) { }

        public override List<double> Intersect(SimpleObject obj)
        {
            
                if (obj is StraightLine)
                {
                    return ((StraightLine)obj).Intersect(this);
                }
                else if (obj is RayLine)
                {
                    return ((RayLine)obj).Intersect(this);
                }
                else if (obj is LineSegment)
                {
                    List<double> intersection = LineLineIntersect(this.args, obj.args);
                    if (intersection.Count >= 2 &&
                    (Dot(intersection[0], intersection[1], obj.args[0], obj.args[1],
                            intersection[0], intersection[1], obj.args[2], obj.args[3]) > 0 ||
                        Dot(intersection[0], intersection[1], this.args[0], this.args[1],
                            intersection[0], intersection[1], this.args[2], this.args[3]) > 0))
                    {
                        intersection.Clear();
                    }
                    return intersection;
                }
                else
                {
                    List<double> intersection = LineCircleIntersect(this.args, obj.args);

                    if (intersection.Count >= 4 &&
                    Dot(intersection[2], intersection[3], this.args[0], this.args[1],
                        intersection[2], intersection[3], this.args[2], this.args[3]) > 0)
                    {
                        intersection.RemoveRange(2, 2);
                    }

                    if (intersection.Count >= 2 &&
                        Dot(intersection[0], intersection[1], this.args[0], this.args[1],
                            intersection[0], intersection[1], this.args[2], this.args[3]) > 0)
                    {
                        intersection.RemoveRange(0, 2);
                    }

                    return intersection;
                }
            
        }
    }


    public class Circle : SimpleObject
    {
        public Circle(List<double> args) : base(args) { }

        public override List<double> Intersect(SimpleObject obj)
        {
           
                if (obj is StraightLine)
                {
                    return ((StraightLine)obj).Intersect(this);
                }
                else if (obj is RayLine)
                {
                    return ((RayLine)obj).Intersect(this);
                }
                else if (obj is LineSegment)
                {
                    return ((LineSegment)obj).Intersect(this);
                }
                else
                {
                    return CircleCircleIntersect(this.args, obj.args);

                }
            
        }
    }

    // The class has some useful function that CommandLine App and Windows app both use.
    // todo: the class need to be tested.
    // todo: need to do exception handle.
    public static class Helper
    {
        // To parse input.
        public static List<SimpleObject> Parse(string text)
        {
            // todo: check if the totol number is right.
            char[] sep = { '\n' };
            string[] lines = text.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            List<SimpleObject> objects = new List<SimpleObject>();
            for (int i = 1; i < lines.Length; i++)
            {
                
                    objects.Add(ParseLine(lines[i]));
               

            }
            return objects;
        }


        // To parse single line to respondent geometric objects.
        public static SimpleObject ParseLine(string line)
        {
            // todo: check if args is right.
            char[] sep = { ' ' };
            string[] tokens = line.Split(sep, StringSplitOptions.RemoveEmptyEntries);
            if (tokens[0] == "L")
            {
                int x1 = int.Parse(tokens[1]);
                int x2 = int.Parse(tokens[2]);
                int x3 = int.Parse(tokens[3]);
                int x4 = int.Parse(tokens[4]);
                if(x1<=-100000||x1>=100000|| x2 <= -100000 || x2 >= 100000 ||
                    x3 <= -100000 || x3 >= 100000 || x4 <= -100000 || x4 >= 100000 )
                {
                    throw new CoordinateRangeException();
                }
                if (x1 == x3 && x2 == x4)
                {
                    throw new PointCoincidentException();
                }
                List<double> args = new List<double>();
                args.Add(x1);
                args.Add(x2);
                args.Add(x3);
                args.Add(x4);
                return new StraightLine(args);
            }
            else if (tokens[0] == "R")
            {
                int x1 = int.Parse(tokens[1]);
                int x2 = int.Parse(tokens[2]);
                int x3 = int.Parse(tokens[3]);
                int x4 = int.Parse(tokens[4]);
                if (x1 <= -100000 || x1 >= 100000 || x2 <= -100000 || x2 >= 100000 ||
                     x3 <= -100000 || x3 >= 100000 || x4 <= -100000 || x4 >= 100000)
                {
                    throw new CoordinateRangeException();
                }
                if (x1 == x3 && x2 == x4)
                {
                    throw new PointCoincidentException();
                }

                List<double> args = new List<double>();
                args.Add(x1);
                args.Add(x2);
                args.Add(x3);
                args.Add(x4);
                return new RayLine(args);
            }
            else if (tokens[0] == "S")
            {
                int x1 = int.Parse(tokens[1]);
                int x2 = int.Parse(tokens[2]);
                int x3 = int.Parse(tokens[3]);
                int x4 = int.Parse(tokens[4]);

                if (x1 <= -100000 || x1 >= 100000 || x2 <= -100000 || x2 >= 100000 ||
                    x3 <= -100000 || x3 >= 100000 || x4 <= -100000 || x4 >= 100000)
                {
                    throw new CoordinateRangeException();
                }
                if (x1 == x3 && x2 == x4)
                {
                    throw new PointCoincidentException();
                }

                List<double> args = new List<double>();
                args.Add(x1);
                args.Add(x2);
                args.Add(x3);
                args.Add(x4);
                return new IntersectionLibrary.LineSegment(args);
            }
            else if(tokens[0]=="C")
            {
                int x1 = int.Parse(tokens[1]);
                int x2 = int.Parse(tokens[2]);
                int x3 = int.Parse(tokens[3]);
                if (x1 <= -100000 || x1 >= 100000 || x2 <= -100000 || x2 >= 100000 )
                    
                {
                    throw new CoordinateRangeException();
                }
                if (x3 <= 0 || x3 >= 100000)
                {
                    throw new RadiusIllegalException();
                }

                List<double> args = new List<double>();
                args.Add(x1);
                args.Add(x2);
                args.Add(x3);
                return new Circle(args);
            }
            else
            {
                throw new TypeException();
            }
        }

        // This is a simple List<double> comparator.
         class SequenceComparer<T> : IEqualityComparer<IEnumerable<T>>
        {
            public bool Equals(IEnumerable<T> seq1, IEnumerable<T> seq2)
            {
                return seq1.SequenceEqual(seq2);
            }

            public int GetHashCode(IEnumerable<T> seq)
            {
                int hash = 1234567;
                foreach (T elem in seq)
                    hash = hash * 37 + elem.GetHashCode();
                return hash;
            }
        }


        // Compute the total intersections.
        public static HashSet<List<double>> Compute(List<SimpleObject> objects)
        {
            List<List<double>> points = new List<List<double>>();
            for (int i = 1; i < objects.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    List<double> point = objects[i].Intersect(objects[j]);
                    if (point.Count == 2)
                    {
                        points.Add(point);
                    }
                    else if (point.Count == 4)
                    {
                        List<double> point1 = new List<double>();
                        List<double> point2 = new List<double>();
                        point1.Add(point[0]);
                        point1.Add(point[1]);
                        point2.Add(point[2]);
                        point2.Add(point[3]);
                        points.Add(point1);
                        points.Add(point2);
                    }
                }
            }

            HashSet<List<double>> set = new HashSet<List<double>>(new SequenceComparer<double>());

            foreach (List<double> p in points)
            {
                set.Add(p);
            }

            return set;
        }
    }
}


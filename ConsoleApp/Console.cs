using IntersectionLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    class ConsoleApp
    {
        // Store all geometric objects.
        public static List<SimpleObject> simpleObjects = new List<SimpleObject>();

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
                List<double> args = new List<double>();
                args.Add(x1);
                args.Add(x2);
                args.Add(x3);
                args.Add(x4);
                return new IntersectionLibrary.LineSegment(args);
            }
            else
            {
                int x1 = int.Parse(tokens[1]);
                int x2 = int.Parse(tokens[2]);
                int x3 = int.Parse(tokens[3]);
                List<double> args = new List<double>();
                args.Add(x1);
                args.Add(x2);
                args.Add(x3);
                return new Circle(args);
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
        public static int Compute(List<SimpleObject> objects)
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

            return set.Count;
        }

        static void Main(string[] args)
        {
            // todo: need to parse commandline args.
            string text = File.ReadAllText("input.txt");
            simpleObjects = Parse(text);
            Console.WriteLine(Compute(simpleObjects));
        }
    }
}

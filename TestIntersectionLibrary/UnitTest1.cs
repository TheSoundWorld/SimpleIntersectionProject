using IntersectionLibrary;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NUnitTestProject1
{
    public class TestStraightLine
    {
        public StraightLine line;
        public StraightLine straightLine;
        public RayLine rayLine1;
        public RayLine rayLine2;
        public LineSegment lineSegment;
        public Circle circle;


        [SetUp]
        public void setup()
        {
            List<double> args = new List<double>();
            args.Add(0);
            args.Add(0);
            args.Add(1);
            args.Add(0);
            line = new StraightLine(args);

            List<double> args1 = new List<double>();
            args1.Add(0);
            args1.Add(1);
            args1.Add(1);
            args1.Add(2);
            straightLine = new StraightLine(args1);

            List<double> args2 = new List<double>();
            args2.Add(0);
            args2.Add(1);
            args2.Add(1);
            args2.Add(2);
            rayLine1 = new RayLine(args2);

            List<double> args3 = new List<double>();
            args3.Add(1);
            args3.Add(2);
            args3.Add(0);
            args3.Add(1);
            rayLine2 = new RayLine(args3);

            List<double> args4 = new List<double>();
            args4.Add(1);
            args4.Add(2);
            args4.Add(0);
            args4.Add(1);
            lineSegment = new LineSegment(args4);

            List<double> args5 = new List<double>();
            args5.Add(0);
            args5.Add(1);
            args5.Add(1);
            circle = new Circle(args5);
        }

        [Test]
        public void TestIntersectWithStraightLine()
        {
            List<double> result = line.Intersect(straightLine);
            List<double> answer = new List<double>();
            answer.Add(-1);
            answer.Add(0);
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }

        [Test]
        public void TestIntersectWithRayLineNoIntersection()
        {
            List<double> result = line.Intersect(rayLine1);
            List<double> answer = new List<double>();
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }

        [Test]
        public void TestIntersectWithRayLine()
        {
            List<double> result = line.Intersect(rayLine2);
            List<double> answer = new List<double>();
            answer.Add(-1);
            answer.Add(0);
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }

        [Test]
        public void TestIntersectWithLineSegmentNoIntersection()
        {
            List<double> result = line.Intersect(lineSegment);
            List<double> answer = new List<double>();
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }

        [Test]
        public void TestIntersectWithCircle()
        {
            List<double> result = line.Intersect(circle);
            List<double> answer = new List<double>();
            answer.Add(0);
            answer.Add(0);
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }
    }
}
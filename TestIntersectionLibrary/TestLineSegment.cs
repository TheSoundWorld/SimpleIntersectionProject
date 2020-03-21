using IntersectionLibrary;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace NUnitTestProject3
{
    [TestFixture]
    public class TestLineSegment
    {
        public LineSegment test;
        public StraightLine straightLine;
        public RayLine rayLine;
        public LineSegment lineSegment;
        public Circle circle;


        [SetUp]
        public void setup()
        {
            List<double> args = new List<double>();
            args.Add(0);
            args.Add(1);
            args.Add(2);
            args.Add(-1);
            test = new LineSegment(args);

            List<double> args1 = new List<double>();
            args1.Add(2);
            args1.Add(1);
            args1.Add(-2);
            args1.Add(1);
            straightLine = new StraightLine(args1);

            List<double> args2 = new List<double>();
            args2.Add(2);
            args2.Add(1);
            args2.Add(2);
            args2.Add(-1);
            rayLine = new RayLine(args2);

            List<double> args3 = new List<double>();
            args3.Add(2);
            args3.Add(1);
            args3.Add(2);
            args3.Add(0);
            lineSegment = new LineSegment(args3);

            List<double> args4 = new List<double>();
            args4.Add(-2);
            args4.Add(3);
            args4.Add(1);

            circle = new Circle(args4);

        }
        [Test]
        public void TestIntersectWithStraightLine()
        {
            List<double> result = test.Intersect(straightLine);
            List<double> answer = new List<double>();
            answer.Add(0);
            answer.Add(1);
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }
        [Test]
        public void TestIntersectWithRayLine()
        {
            List<double> result = test.Intersect(rayLine);
            List<double> answer = new List<double>();
            answer.Add(2);
            answer.Add(-1);
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }
        [Test]
        public void TestIntersectWithLineSegment()
        {
            List<double> result = test.Intersect(lineSegment);
            List<double> answer = new List<double>();       
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }

        [Test]
        public void TestIntersectWithCircle()
        {
            List<double> result = test.Intersect(circle);
            List<double> answer = new List<double>();
        
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }
    }
}

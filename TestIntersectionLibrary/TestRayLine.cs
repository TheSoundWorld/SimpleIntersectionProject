using IntersectionLibrary;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;


namespace NUnitTestProject2
{
    [TestFixture]
    public class TestRayLine
    {
        public RayLine test;
        public StraightLine straightLine;
        public RayLine rayLine;
        public LineSegment lineSegment;
        public Circle circle;
        public RayLine rayLine1;
        public Circle circle1;
        public Circle circle2;
        public LineSegment lineSegment1;


        [SetUp]
        public void setup()
        {
            List<double> args = new List<double>();
            args.Add(2);
            args.Add(1);
            args.Add(2);
            args.Add(-1);
            test = new RayLine(args);

            List<double> args1 = new List<double>();
            args1.Add(2);
            args1.Add(1);
            args1.Add(-2);
            args1.Add(1);
            straightLine = new StraightLine(args1);

            List<double> args2 = new List<double>();
            args2.Add(1);
            args2.Add(2);
            args2.Add(3);
            args2.Add(1);
            rayLine = new RayLine(args2);

            List<double> args3 = new List<double>();
            args3.Add(0);
            args3.Add(1);
            args3.Add(2);
            args3.Add(-1);
            lineSegment = new LineSegment(args3);

            List<double> args4 = new List<double>();
            args4.Add(1);
            args4.Add(0);
            args4.Add(1);

            circle = new Circle(args4);

            List<double> args5 = new List<double>();
            args5.Add(0);
            args5.Add(0);
            args5.Add(1);
            args5.Add(0);
            rayLine1 = new RayLine(args5);

            List<double> args6 = new List<double>();
            args6.Add(2);
            args6.Add(3);
            args6.Add(1);

            circle1 = new Circle(args6);

            List<double> args7 = new List<double>();
            args7.Add(2);
            args7.Add(-1);
            args7.Add(1);

            circle2 = new Circle(args7);

            List<double> args8 = new List<double>();
            args8.Add(0);
            args8.Add(1);
            args8.Add(1);
            args8.Add(0);
            lineSegment1 = new LineSegment(args8);
        }
        [Test]
        public void TestIntersectWithStraightLine()
        {
            List<double> result = test.Intersect(straightLine);
            List<double> answer = new List<double>();
            answer.Add(2);
            answer.Add(1);
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }
        [Test]
        public void TestIntersectWithRayLine()
        {
            List<double> result = test.Intersect(rayLine);
            List<double> answer = new List<double>();

            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }
        [Test]
        public void TestIntersectWithLineSegment()
        {
            List<double> result = test.Intersect(lineSegment);
            List<double> answer = new List<double>();
            answer.Add(2);
            answer.Add(-1);
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }

        [Test]
        public void TestIntersectWithCircle()
        {
            List<double> result = test.Intersect(circle);
            List<double> answer = new List<double>();
            answer.Add(2);
            answer.Add(0);
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }

        [Test]
        public void TestIntersectWithRayLine1()
        {
            List<double> result = test.Intersect(rayLine1);
            List<double> answer = new List<double>();
            answer.Add(2);
            answer.Add(0);
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }

        [Test]
        public void TestIntersectWithCircle1()
        {
            List<double> result = test.Intersect(circle1);
            List<double> answer = new List<double>();
            
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }

        public void TestIntersectWithCircle2()
        {
            List<double> result = test.Intersect(circle2);
            List<double> answer1 = new List<double>();
            List<double> answer2= new List<double>();
            answer1.Add(2);
            answer1.Add(0);
            answer1.Add(2);
            answer1.Add(-2);

            answer2.Add(2);
            answer2.Add(-2);
            answer2.Add(2);
            answer2.Add(0);
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer1)| Enumerable.SequenceEqual(result, answer2));
        }
        [Test]
        public void TestIntersectWithLineSegment1()
        {
            List<double> result = test.Intersect(lineSegment1);
            List<double> answer = new List<double>();
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }
    }
}

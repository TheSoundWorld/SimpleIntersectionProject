using IntersectionLibrary;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Diagnostics;

namespace NUnitTestProject4
{
    [TestFixture]
    public class TestCircle
    {
        public Circle test;
        public StraightLine straightLine;
        public RayLine rayLine;
        public LineSegment lineSegment;
        public Circle circle1;
        public Circle circle2;
        public Circle circle3;


        [SetUp]
        public void setup()
        {
            List<double> args = new List<double>();
            args.Add(0);
            args.Add(0);
            args.Add(2);
            
            test = new Circle(args);

            List<double> args1 = new List<double>();
            args1.Add(2);
            args1.Add(1);
            args1.Add(2);
            args1.Add(0);
            straightLine = new StraightLine(args1);

            List<double> args2 = new List<double>();
            args2.Add(1);
            args2.Add(1);
            args2.Add(-5);
            args2.Add(-1);
            rayLine = new RayLine(args2);

            List<double> args3 = new List<double>();
            args3.Add(0);
            args3.Add(3);
            args3.Add(1);
            args3.Add(3);
            lineSegment = new LineSegment(args3);

            List<double> args4 = new List<double>();
            args4.Add(1);
            args4.Add(0);
            args4.Add(1);
            circle1= new Circle(args4);

            List<double> args5 = new List<double>();
            args5.Add(0);
            args5.Add(0);
            args5.Add(3);
            circle2 = new Circle(args5);

            List<double> args6 = new List<double>();
            args6.Add(2);
            args6.Add(0);
            args6.Add(2);
            circle3 = new Circle(args6);

        }
        [Test]
        public void TestIntersectWithStraightLine()
        {
            List<double> result = test.Intersect(straightLine);
            List<double> answer = new List<double>();
            answer.Add(2);
            answer.Add(0);
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
        }
        [Test]
        public void TestIntersectWithRayLine()
        {
            List<double> result = test.Intersect(rayLine);
            List<double> answer = new List<double>();
            answer.Add(-2);
            answer.Add(0);
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
        public void TestIntersectWithCircle1()
        {
            List<double> result = test.Intersect(circle1);
            List<double> answer = new List<double>();
            answer.Add(2);
            answer.Add(0);
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
                
        }

        [Test]
        public void TestIntersectWithCircle2()
        {
            List<double> result = test.Intersect(circle2);
            List<double> answer= new List<double>();

            Assert.IsTrue(Enumerable.SequenceEqual(result, answer));
               
        }

        [Test]
        public void TestIntersectWithCircle3()
        {
            List<double> result = test.Intersect(circle3);
            List<double> answer1 = new List<double>();
            answer1.Add(1);
            answer1.Add(Math.Sqrt(3));
            answer1.Add(1);
            answer1.Add(-1*Math.Sqrt(3));
            List<double> answer2 = new List<double>();
            answer2.Add(1);
            answer2.Add(-1 * Math.Sqrt(3));
            answer2.Add(1);
            answer2.Add(Math.Sqrt(3));
            Assert.IsTrue(Enumerable.SequenceEqual(result, answer1) |
                Enumerable.SequenceEqual(result, answer2));
        }
    }
}

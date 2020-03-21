using IntersectionLibrary;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;

namespace NUnitTestProject5
{
    [TestFixture]
   public class TestHelper
    {

        
        public StraightLine straightLine;
        public RayLine rayLine;
        public LineSegment lineSegment;
        public Circle circle1;
        public Circle circle2;
        public Circle circle3;
        public Circle circle4;


        [SetUp]
        public void setup()
        {                   

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
            args3.Add(0);
            args3.Add(0);
            lineSegment = new LineSegment(args3);

            List<double> args4 = new List<double>();
            args4.Add(1);
            args4.Add(0);
            args4.Add(1);
            circle1 = new Circle(args4);

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

            List<double> args7 = new List<double>();
            args7.Add(0);
            args7.Add(0);
            args7.Add(2);
            circle4 = new Circle(args7);

        }

        [Test]
        public void TestCompute()
        {
            List<SimpleObject> objects = new List<SimpleObject>();
            objects.Add(straightLine);
            objects.Add(rayLine);
            objects.Add(lineSegment);
            objects.Add(circle1);
            objects.Add(circle2);
            objects.Add(circle3);
            objects.Add(circle4);
            HashSet<List<double>> set = Helper.Compute(objects);
            Assert.AreEqual(set.Count, 18);
        }

        [Test]
        public void TestParse()
        {
            string text = "3\nL 2 1 2 0\nR 1 1 - 5 - 1\nS 0 3 0 0\nC 1 1 2";
            List<SimpleObject> objects = Helper.Parse(text);
            List<double> object0 = new List<double>();
            List<double> object1 = new List<double>();
            List<double> object2 = new List<double>();
            List<double> object3 = new List<double>();

            object0.Add(2);
            object0.Add(1);
            object0.Add(2);
            object0.Add(0);

            object1.Add(1);
            object1.Add(1);
            object1.Add(-5);
            object1.Add(-1);

            object2.Add(0);
            object2.Add(3);
            object2.Add(0);
            object2.Add(0);

            object3.Add(1);
            object3.Add(1);
            object3.Add(2);

            Assert.AreEqual(typeof(StraightLine), objects[0].GetType());
            Assert.IsTrue(Enumerable.SequenceEqual(objects[0].args, object0));
            Assert.AreEqual(typeof(RayLine), objects[1].GetType());
            Assert.IsTrue(Enumerable.SequenceEqual(objects[1].args, object1));
            Assert.AreEqual(typeof(LineSegment), objects[2].GetType());
            Assert.IsTrue(Enumerable.SequenceEqual(objects[2].args, object2));
            Assert.AreEqual(typeof(Circle), objects[3].GetType());
            Assert.IsTrue(Enumerable.SequenceEqual(objects[3].args, object3));
        }

       



    }
}

using IntersectionLibrary;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;

namespace NUnitTestProject6
{
    [TestFixture]
    public class TestException
    {
        [Test]
        public void TestTypeException()
        {
            TypeException exception = null;
            try
            {
                Helper.ParseLine("Q 1 2 3 4");
            }catch(TypeException ex)
            {
                exception = ex;
            }
            Assert.AreEqual(typeof(TypeException), exception.GetType());
        }

        [Test]
        public void TestCoordinateRangeException()
        {
            CoordinateRangeException exception = null;
            try
            {
                Helper.ParseLine("L 100000 3 2 1");
            }catch(CoordinateRangeException ex)
            {
                exception = ex;
            }
            Assert.AreEqual(typeof(CoordinateRangeException), exception.GetType());
        }

        [Test]
        public void TestRadiusIllegalException()
        {
            RadiusIllegalException exception = null;
            try
            {
                Helper.ParseLine("C 2 3 -3");
            }catch(RadiusIllegalException ex)
            {
                exception = ex;
            }
            Assert.AreEqual(typeof(RadiusIllegalException), exception.GetType());
        }

        [Test]
        public void TestPointCoincidentException()
        {
            PointCoincidentException exception = null;
            try
            {
                Helper.ParseLine("R 1 2 1 2");
            }catch(PointCoincidentException ex)
            {
                exception = ex;
            }
            Assert.AreEqual(typeof(PointCoincidentException), exception.GetType());
        }

        [Test]
        public void TestIntersectionsInfiniteException()
        {
            IntersectionsInfiniteException exception = null;
            try
            {
                List<double> l1 = new List<double>();
                l1.Add(0);
                l1.Add(0);
                l1.Add(0);
                l1.Add(1);
                List<double> l2 = new List<double>();
                l2.Add(0);
                l2.Add(-1);
                l2.Add(0);
                l2.Add(-2);
                SimpleObject.LineLineIntersect(l1, l2);
            }catch(IntersectionsInfiniteException ex)
            {
                exception = ex;
            }
            Assert.AreEqual(typeof(IntersectionsInfiniteException), exception.GetType());
        }
    }
}

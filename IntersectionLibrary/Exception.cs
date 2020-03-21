using System;
using System.Collections.Generic;
using System.Text;

namespace IntersectionLibrary
{
    public class TypeException:Exception
    {
        public TypeException():base()
        {
            Console.WriteLine("SimpleObjectType is illegal!");
            
        }
    }
    public class CoordinateRangeException : Exception
    {
        public CoordinateRangeException() : base()
        {
            Console.WriteLine("Coordinate range is illgeal!");
        }
    }

    public class RadiusIllegalException : Exception
    {
        public RadiusIllegalException() : base()
        {
            Console.WriteLine("Radius is illegal!");
        }
    }

    public class PointCoincidentException : Exception
    {
        public PointCoincidentException() : base()
        {
            Console.WriteLine("Two points are coincident!");
        }
    }

    public class IntersectionsInfiniteException : Exception
    {
        public IntersectionsInfiniteException() : base()
        {
            Console.WriteLine("Intersections are infinite!");
        }
    }
}

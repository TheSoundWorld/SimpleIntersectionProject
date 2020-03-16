using IntersectionLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp
{
    class ConsoleApp
    {
        static void Main(string[] args)
        {
            // todo: need to parse commandline args.
            List<SimpleObject> simpleObjects = new List<SimpleObject>();

            string text = File.ReadAllText("input.txt");
            simpleObjects = Helper.Parse(text);
            Console.WriteLine(Helper.Compute(simpleObjects).Count);
        }
    }
}

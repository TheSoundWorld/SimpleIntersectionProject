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

            string inFile = args[2];
            string outFile = args[4];
            FileStream fs = new FileStream(outFile, FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);

            string text = File.ReadAllText(inFile);
            try
            {
                simpleObjects = Helper.Parse(text);

                sw.Write(Helper.Compute(simpleObjects).Count);
            }
            catch (Exception) { };
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}

using System;
using System.Numerics;
using MathNet.Numerics.Distributions;
using Shared._2d;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CFTree cFTree = new CFTree();
            cFTree.Threshold = 0.1f;
            cFTree.BranchingFactor = 4;
            cFTree.Add(new Vector2(0, 2));
            cFTree.Add(new Vector2(0, 3));
            cFTree.Add(new Vector2(1, 4));
            cFTree.Add(new Vector2(2, 1));
            cFTree.Add(new Vector2(1, 5));
            cFTree.Add(new Vector2(2, 1));



            cFTree.Add(new Vector2(3, 2));
            cFTree.Add(new Vector2(1.5f, 2.2f));
            cFTree.Add(new Vector2(2.5f, 0.22f));
            cFTree.Add(new Vector2(0.5f, 2.89f));
            cFTree.Add(new Vector2(1.8f, 4.22f));
            cFTree.Add(new Vector2(1.2f, 1.02f));
            cFTree.Add(new Vector2(0.5f, 2.51f));
            cFTree.Add(new Vector2(2.5f, 0.52f));
            //Console.WriteLine(RadiusWithData(new Vector2(10, 70), new Vector2(10, 10)));
            //Console.WriteLine(RadiusWithData(new Vector2(14, 70), new Vector2(14, 10)));

            var results = cFTree.Clustering();
            results.Reverse();
            //Console.WriteLine(RadiusWithData(new Vector2(70, 10), new Vector2(10, 10)));
            //Console.WriteLine(RadiusWithData(new Vector2(70, 14), new Vector2(10, 14)));
            Console.WriteLine("Hello World!");
        }
        public static float RadiusWithData(Vector2 d1, Vector2 d2)
        {
            var ss = d1 * d1 + d2 * d2;
            var ls = d1 + d2;
            var n = 2;

            var ts = ss - (ls * ls / n);
            var ms = n;

            return Vector2.SquareRoot(ts / ms).Length();
        }
    }
}

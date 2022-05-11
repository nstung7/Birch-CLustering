using System;
using MathNet.Numerics.Distributions;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var f = new FisherSnedecor(4, 2);
            var p2 = f.CumulativeDistribution(19.84);
            var p = f.DensityLn(19.84);
            Console.WriteLine("Hello World!");
        }
    }
}

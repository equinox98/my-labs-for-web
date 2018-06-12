using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipeline
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = Initialization.Reader.GetFile();
            res = Algorithms.Network.GetAdjacencyMatrix(res);

            int costPerKm = 0;
            int buildCostPerKm = 0;

            Console.WriteLine("Enter cost per 1 km :");
            costPerKm = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter build cost per 1 km :");
            buildCostPerKm = Convert.ToInt32(Console.ReadLine());

            var r = Algorithms.Network.Kruskall(res, costPerKm, buildCostPerKm);

            foreach(var tmp in r)
            {
                Console.WriteLine("{0} -> {1}", tmp.From + 1, tmp.To + 1);
            }

            Console.ReadKey();
        }
    }
}

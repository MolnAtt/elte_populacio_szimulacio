using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elte_populacio_szimulacio
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] H = new double[] { 0.1, 0.2, 0.3, 0.4, 1 };
            double[] Sz = new double[] { 0.3, 0.4, 0.6, 0.3, 0.2 };
            Populacio P = new Populacio(H, Sz, 100, true);

            P.Szimuláció(20, true);

            Console.ReadKey();
        }
    }
}

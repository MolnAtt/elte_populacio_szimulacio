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
            double[] H = new double[] { 0.4, 0.2, 0.43, 0.7, 1 };
            double[] Sz = new double[] { 0.5, 0.7, 0.8, 0.6, 0.5 };
            Populacio P = new Populacio(H, Sz, 100, true);

            P.Szimuláció_Katasztrófáig(100, true);

            Console.ReadKey();
        }
    }
}

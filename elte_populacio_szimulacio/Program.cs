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
            double[] H = new double[] { 0.1, 0.2, 0.2, 0.2, 1 };
            double[] Sz = new double[] { 0.1, 0.2, 0.2, 0.2, 0 };
            Populacio P = new Populacio(H, Sz, 10);

            for (int i = 0; i < 10; i++)
            {
                P.Szimulációs_lépés();
                P.Diagnosztika();
            }

            Console.ReadKey();
        }
    }
}

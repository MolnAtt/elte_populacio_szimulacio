using System;
using System.Collections.Generic;

namespace elte_populacio_szimulacio
{
    class Populacio
    {
        double[] H, Sz;
        Random r;
        List<int> T;


        public Populacio(double[] H, double[] Sz, int N)
        {
            this.H = H;
            this.Sz = Sz;
            this.r = new Random();
            this.T = new List<int>(20 * N);
            for (int i = 0; i < N; i++)
            {
                T.Add(1);
            }
        }

        public void Szimulációs_lépés()
        {
            for (int i = 0; i < T.Count; i++)
            {
                if (Véletlen<H[T[i]])
                    T[i] = 0;
                else
                    if (Véletlen<Sz[T[i]])
                        T.Add(1);
            }
            Tömörítés();
        }

        double Véletlen { get => r.NextDouble(); } 

        public void Tömörítés()
        {
            for (int i = 0; i < T.Count; i++)
                if (T[i] == 0)
                    T.RemoveAt(i--);
        }

        public void Diagnosztika()
        {
            foreach (int item in T)
                Console.Write($"{item} ");
            Console.WriteLine();
        }
    }
}
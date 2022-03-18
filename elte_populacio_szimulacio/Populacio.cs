using System;
using System.Collections.Generic;

namespace elte_populacio_szimulacio
{
    class Populacio
    {
        double[] H, Sz;
        Random r;
        List<int> T;
        bool debug;


        public Populacio(double[] H, double[] Sz, int N, bool debug = false)
        {
            this.H = H;
            this.Sz = Sz;
            this.r = new Random();
            this.T = new List<int>(20 * N);
            this.debug = debug;
            for (int i = 0; i < N; i++)
            {
                T.Add(1);
            }
        }

        public void Szimuláció(int lépésszám, bool debug)
        {
            Diagnosztika();
            for (int i = 0; i < lépésszám; i++)
            {
                Szimulációs_lépés();
                Diagnosztika();
            }
        }

        public void Szimulációs_lépés()
        {
            for (int i = 0; i < T.Count; i++)
            {
                if (Véletlen < H[T[i]])
                {
                    T[i] = 0;
                    //Console.WriteLine($"{i} meghalt.");
                }
                else
                {
                    if (Véletlen < Sz[T[i]])
                    {
                        T.Add(1);
                    //  Console.WriteLine($"{i} megszült.");
                    }

                    T[i]++;
                }
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
            if (debug)
            {
                foreach (int item in T)
                    Console.Write($"{item} ");
                Console.WriteLine();
            }
        }
    }
}
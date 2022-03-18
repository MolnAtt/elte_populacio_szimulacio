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
  //          Diagnosztika();
            Diagnosztika_Korcsoport_sorba();
            for (int i = 0; i < lépésszám; i++)
            {
                Szimulációs_lépés();
//                Diagnosztika();
                Diagnosztika_Korcsoport_sorba();
            }
        }

        public void Szimulációs_lépés()
        {
            int N = T.Count;
            for (int i = 0; i < N; i++)
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

        public int[] Korcsoportonkénti_sűrűségfüggvény()
        {
            int[] sűrűségfüggvény = new int[H.Length];

            foreach (int item in T)
                sűrűségfüggvény[item-1]++;

            return sűrűségfüggvény;
        }

        public void Diagnosztika_Korcsoport()
        {
            int[] korcsoportos_sűrűségfüggvény = Korcsoportonkénti_sűrűségfüggvény();
            for (int i = 0; i < korcsoportos_sűrűségfüggvény.Length; i++)
                Console.WriteLine($"{i+1} éves: {korcsoportos_sűrűségfüggvény[i]} db");

        }


        public void Diagnosztika_Korcsoport_sorba()
        {
            int[] korcsoportos_sűrűségfüggvény = Korcsoportonkénti_sűrűségfüggvény();
            for (int i = 0; i < korcsoportos_sűrűségfüggvény.Length; i++)
                Console.Write($"[{i + 1}] {korcsoportos_sűrűségfüggvény[i]}\t");
            Console.WriteLine();
        }


    }
}
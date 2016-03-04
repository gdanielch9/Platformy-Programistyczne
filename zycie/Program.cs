/*
Daniel Chołuj
Marcin Chrzczanowicz
Czw / 17.05
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   

namespace zycie
{

    class Plansza
    {
        public int[,] Tab;          // Plansza glowna
        public int[,] Tab2;         // Plansza pomocnicza

        /*
        Ustala rozmiar planszy.
        Jeśli podana jest tylko jedna wspolrzedna to tablica jest kwadratowa.
        */
        public Plansza(int x, int? y)
        {
            if (y == null)
                y = x;

            if (x < 0 || y < 0)
            {
                Console.WriteLine("Zly wymiar macierzy!");
                Console.ReadKey();
                System.Environment.Exit(1);
            }

            Tab = new int[x, (int)y];
            Tab2 = new int[x, (int)y];
        }

        /*
        Losowanie elementow planszy
        */
        public void Generuj()
        {
            Random rand = new Random();
            for (int i = 0; i < 20; ++i)
            {
                for (int j = 0; j < 20; ++j)
                {
                    Tab[i, j] = rand.Next(0,2);
                }
            }
        }
        
        /*
        Wiadomo
        */
        public void Wyswietl()
        {
            for (int i = 0; i < 20; ++i)
            {
                for (int j = 0; j < 20; ++j)
                {
                    Console.Write(Tab[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        /*
        Kolejne scenariusze pisane przez zycie po nacisnieciu klawisza przez uzytkownika
        */
        public void Iteracja()
        {
            int Sasiedzi = 0;       // liczba sasiadow analizowanej komorki
            for (int i = 0; i < 20; ++i)
            {
                for (int j = 0; j < 20 ; ++j)
                {
                    int Zm = Tab[i, j];

                        Sasiedzi = 0;

                        if (i != 0 && j != 0) if (Tab[i - 1, j - 1] == 1)
                            Sasiedzi += 1;

                        if (i != 0) if (Tab[i - 1, j] == 1)
                            Sasiedzi += 1;

                        if (i != 0 && j != 19) if( Tab[i - 1, j + 1] == 1)
                            Sasiedzi += 1;

                        if (j != 19) if(Tab[i, j + 1] == 1)
                            Sasiedzi += 1;

                        if (j != 0) if( Tab[i, j - 1] == 1)
                            Sasiedzi += 1;

                        if (i != 19 && j != 19) if (Tab[i + 1, j + 1] == 1)
                            Sasiedzi += 1;

                        if (i != 19) if( Tab[i + 1, j] == 1) 
                            Sasiedzi += 1;

                        if (i != 19 && j != 0) if (Tab[i + 1, j - 1] == 1)
                            Sasiedzi += 1;

                        Tab2[i, j] = Tab[i, j];
                        if(Zm == 1)
                        {
                            if (Sasiedzi < 2 || Sasiedzi > 3)
                                Tab2[i, j] = 0;
                        }
                        else
                        {
                            if(Sasiedzi == 3)
                                Tab2[i, j] = 1;
                        }
                }
            }
            
            for (int i = 0; i < 20; ++i)
            {
                for (int j = 0; j < 20; ++j)
                {
                    Tab[i, j] = Tab2[i, j];
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo klawisz;
            Plansza Obj = new Plansza(20,20);
            Obj.Generuj();
                        
            while (true)
            {
                Obj.Wyswietl();
                Obj.Iteracja();
                klawisz = Console.ReadKey();

                if (klawisz.Key == ConsoleKey.Escape || klawisz.Key == ConsoleKey.Q)    // wychodzimy z gry
                    break;

                Console.Clear();
            }

        }
    }
}

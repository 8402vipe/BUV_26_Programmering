using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ConsoleSnake
{
    class Program
    {
        // Spillets innstillinger og brettstørrelse
        const int BrettBredde = 40;
        const int BrettHoyde = 20;
        const int HastighetMs = 100; // Lavere tall = raskere spill

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(BrettBredde + 2, BrettHoyde + 2);
            Console.SetBufferSize(BrettBredde + 2, BrettHoyde + 2);

            while (true)
            {
                KjorSpill();

                Console.SetCursorPosition(BrettBredde / 2 - 10, BrettHoyde / 2);
                Console.Write("GAME OVER! Spill igjen? (J/N)");

                var svar = Console.ReadKey(true).Key;
                if (svar != ConsoleKey.J) break;
            }
        }

        static void KjorSpill()
        {
            Console.Clear();
            TegnBane();

            // Initialiser slangen (starter midt på brettet)
            var slange = new List<Posisjon>
            {
                new Posisjon(BrettBredde / 2, BrettHoyde / 2),
                new Posisjon(BrettBredde / 2 - 1, BrettHoyde / 2),
                new Posisjon(BrettBredde / 2 - 2, BrettHoyde / 2)
            };

            var retning = Retning.Hoyre;
            Posisjon mat = GenererMat(slange);
            TegnMat(mat);

            int poeng = 0;
            bool spillAktivt = true;

            while (spillAktivt)
            {
                // Håndter input fra brukeren
                if (Console.KeyAvailable)
                {
                    var tast = Console.ReadKey(true).Key;
                    retning = tast switch
                    {
                        ConsoleKey.UpArrow when retning != Retning.Ned => Retning.Opp,
                        ConsoleKey.DownArrow when retning != Retning.Opp => Retning.Ned,
                        ConsoleKey.LeftArrow when retning != Retning.Hoyre => Retning.Venstre,
                        ConsoleKey.RightArrow when retning != Retning.Venstre => Retning.Hoyre,
                        _ => retning
                    };
                }

                // Beregn det nye hodet basert på retning
                Posisjon hode = slange.First();
                Posisjon nyttHode = retning switch
                {
                    Retning.Opp => new Posisjon(hode.X, hode.Y - 1),
                    Retning.Ned => new Posisjon(hode.X, hode.Y + 1),
                    Retning.Venstre => new Posisjon(hode.X - 1, hode.Y),
                    Retning.Hoyre => new Posisjon(hode.X + 1, hode.Y),
                    _ => hode
                };

                // Sjekk kollisjon med vegger eller seg selv
                if (nyttHode.X <= 0 || nyttHode.X >= BrettBredde + 1 ||
                    nyttHode.Y <= 0 || nyttHode.Y >= BrettHoyde + 1 ||
                    slange.Any(s => s.X == nyttHode.X && s.Y == nyttHode.Y))
                {
                    spillAktivt = false;
                    continue;
                }

                // Legg til det nye hodet i slangen
                slange.Insert(0, nyttHode);
                Console.SetCursorPosition(nyttHode.X, nyttHode.Y);
                Console.Write("O"); // Slangens hode/kropp

                // Sjekk om slangen spiser maten
                if (nyttHode.X == mat.X && nyttHode.Y == mat.Y)
                {
                    poeng += 10;
                    mat = GenererMat(slange);
                    TegnMat(mat);
                }
                else
                {
                    // Fjern halen hvis den ikke spiste mat
                    Posisjon hale = slange.Last();
                    Console.SetCursorPosition(hale.X, hale.Y);
                    Console.Write(" ");
                    slange.Remove(hale);
                }

                // Vis poengsummen på toppen
                Console.SetCursorPosition(0, 0);
                Console.Write($"Poeng: {poeng}");

                Thread.Sleep(HastighetMs);
            }
        }

        static void TegnBane()
        {
            // Tegn topp og bunnvegg
            for (int x = 0; x <= BrettBredde + 1; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.Write("#");
                Console.SetCursorPosition(x, BrettHoyde + 1);
                Console.Write("#");
            }

            // Tegn sidevegger
            for (int y = 0; y <= BrettHoyde + 1; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("#");
                Console.SetCursorPosition(BrettBredde + 1, y);
                Console.Write("#");
            }
        }

        static Posisjon GenererMat(List<Posisjon> slange)
        {
            var rand = new Random();
            while (true)
            {
                int x = rand.Next(1, BrettBredde + 1);
                int y = rand.Next(1, BrettHoyde + 1);

                // Sørg for at maten ikke spawner oppå slangen
                if (!slange.Any(s => s.X == x && s.Y == y))
                {
                    return new Posisjon(x, y);
                }
            }
        }

        static void TegnMat(Posisjon mat)
        {
            Console.SetCursorPosition(mat.X, mat.Y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("*");
            Console.ResetColor();
        }
    }

    struct Posisjon
    {
        public int X { get; }
        public int Y { get; }
        public Posisjon(int x, int y) { X = x; Y = y; }
    }

    enum Retning { Opp, Ned, Venstre, Hoyre }
}

using System;

namespace ChessBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            // När programmet startar ska användaren få mata in en siffra
            Console.Write("Mata in en siffra för storlek på schackbrädet: ");
            string input = Console.ReadLine();

            // Tips: Konvertera texten till en integer (heltal)
            int size = Int32.Parse(input);

            // 3. Skapa schackbrädet med nästlade loopar (rader och kolumner)
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    // Om summan av radnummer och kolumnnummer är jämn blir det en svart ruta, annars en vit.
                    // Detta gör att rutorna växlar färg på varje rad och kolumn.
                    if ((row + col) % 2 == 0)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write("o");
                    }
                }

                // Radbyte efter att en hel rad med kolumner har skrivits ut
                Console.WriteLine();
            }

            // Håller kvar konsolfönstret så att du hinner se resultatet
            Console.ReadLine();
        }
    }
}
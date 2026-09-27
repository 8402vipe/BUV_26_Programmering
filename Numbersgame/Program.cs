// Viktoria Permanova - BUV26

using System;

namespace NumbersGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            int secretNumber = random.Next(1, 21);
            int attempts = 5;
            bool guessedCorrectly = false;

            Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket? Du får fem försök.");

            for (int i = 0; i < attempts; i++)
            {
                Console.Write("Gissa ett tal mellan 1 och 20: ");
                int guess = Convert.ToInt32(Console.ReadLine());

                if (CheckGuess(guess, secretNumber))
                {
                    Console.WriteLine("Wohoo! Du gjorde det!");
                    guessedCorrectly = true;
                    break;
                }

                if (guess < secretNumber)
                {
                    Console.WriteLine("Tyvärr du gissade för lågt!");
                }
                else
                {
                    Console.WriteLine("Tyvärr du gissade för högt!");
                }
            }

            if (!guessedCorrectly)
            {
                Console.WriteLine("Tyvärr du lyckades inte gissa talet på fem försök!");
            }
        }

        static bool CheckGuess(int guess, int secretNumber)
        {
            return guess == secretNumber;
        }
    }
}
//övnings loop julgran
using System;

class Program
{
    static void Main()
    {
        string _tred = "*";
        /*int _antallrader = 5;*/
        Console.WriteLine("Skriv inn et tall for antall rader:");int _antallrader = int.Parse(Console.ReadLine());
        for (int i = 0; i < _antallrader; i++)
        {
            Console.Write($"{_tred}");
            for (int j = 1; j < _antallrader; j++) //gjör sånn at vi får 5 linjer efterhverandre
            {
                Console.Write($"{_tred}\n");
                /* Console.WriteLine($"{_tred}");*/
            }
        }
        
     
    }    
        
        
}





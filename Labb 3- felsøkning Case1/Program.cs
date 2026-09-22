//Case 1
// Koden vil kun vise om tallet er mindre enn 3 eller større enn 3, hvis syntax feil rettes
int number =2;

if (number > 3)
    {
    Console.WriteLine("Talet är större än tre"); //mangler ;
    }
else if (number < 3) //Ikke noe som heter elseif men else if
    {
    Console.WriteLine("Talet är mindre än tre");
    }
else // Legger til om tallet er lik 3
{ Console.WriteLine("Talet lik tre"); 
}

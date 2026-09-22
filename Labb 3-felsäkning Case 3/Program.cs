//Case 3
for (int i = 1; i <= 5; i++) //Saknas ++,som visar att för loop går vidare till nästa tal
{
    for (int j = 1; j <= i; j++)//saknas ++,och detta gör att förloop går vidare till nästa tal och repeterar inte oäntligt loop
    {
        Console.Write(j + " ");
    }
    Console.WriteLine();
}

using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string  firstName = Console.ReadLine();
        Console.Write("What is your last name? ");
        string  lasttName = Console.ReadLine();
        Console.WriteLine("");
        Console.WriteLine($"Your name is {lasttName}, {firstName} {lasttName}.");
    }
}
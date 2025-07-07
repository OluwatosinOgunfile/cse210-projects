using System;

class Program
{
    static void Main(string[] args)
    {
        int attempts = 0;

        Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101);

        int guess;

        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());

            if (guess > magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it!");
            }

            attempts++;


        } while (guess != magicNumber);

        Console.WriteLine($"You made {attempts} attempts in total.");

    }
}
using System;

class Program
{
    static void Main(string[] args)
    {

        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the Program!");
        }

        static string PromptUserName()
        {
            Console.Write("Please enter your name: ");
            string userName = Console.ReadLine();
            return userName;
        }

        static int PromptUserNumber()
        {
            Console.Write("Please enter your favorite number: ");
            int userNumber = int.Parse(Console.ReadLine());
            return userNumber;
        }

        static int SquareNumber(int userNumber)
        {
            int sq = userNumber * userNumber;
            return sq;
        }

        static void DisplayResult(string userName, int square)
        {
            Console.WriteLine($"{userName}, the square of your number is {square}");
        }

        DisplayWelcome();
        string user = PromptUserName();
        int number = PromptUserNumber();
        int result = SquareNumber(number);
        DisplayResult(user, result);

    }
}
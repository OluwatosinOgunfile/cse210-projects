using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        // create new instances of reference, scripture, and word
        Reference reference = new Reference();
        reference.LoadReference();
        Scripture scripture = new Scripture();
        scripture.LoadScriptures();
        Word word = new Word();

        // display the user option menu
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("\n**** Welcome ****\n");
        Console.ForegroundColor = ConsoleColor.White;

        string userChoice = "";

        while (userChoice != "q")
        {
            userChoice = UserChoice();
            switch (userChoice)
            {
                case "s":
                    string script = scripture.RandomScripture();
                    string ref1 = reference.GetReference(scripture);
                    word.GetRenderedText(scripture);

                    while (word._hiddenWords.Count < word._result.Length)
                    {
                        word.Show(ref1);
                        word.GetReadKey();
                    }
                    word.Show(ref1);
                    break;
                case "q":
                    Console.WriteLine("\n*** Thanks. See you again soon! ***\n");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nInvalid Option ... Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }

    static string UserChoice()
    // Method to display choices to user
    {
        Reference reference = new Reference();

        string choices = $@"
Select an option:

S. Display a scripture to memorize
Q. Quit

Your option:  ";

        Console.Write(choices);

        string userInput = Console.ReadLine();
        userInput.ToLower();
        string userChoice = "";
        // This block catches invalid values that are entered
        try
        {
            if ((!(userInput == "s")) & (!(userInput == "q")))
            {
                userChoice = "";
            }
            else
            {
                userChoice = userInput;
            }
        }
        catch (FormatException)
        {
            userChoice = "";
        }
        catch (Exception exception)
        {
            Console.WriteLine(
                $"Unexpected error:  {exception.Message}");
        }
        return userChoice;
    }

    // Stretch requirements
    // 1. Added menu for functionality
    // 2. Saved scriptures to DataText.Txt

}
using System;

class Program
{
    static void Main(string[] args)
    {
        int action = 0;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write("\n\t=== The Journal App ===");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("\n\t*** 'There shall be a record kept among you ... (D & C 21:1)' ***\n");

        // create new journal
        Journal jrnl = new Journal();
        PromptGenerator jp = new PromptGenerator();

        while (action != 5)
        {
            // request user input

            action = Choices();
            switch (action)
            {
                case 1:
                    // Write journal Entry
                    jrnl.AddEntry();

                    // add entry into journal
                    jrnl._entries.Add(entry);

                    break;
                case 2:
                    // Show inputted journal entries
                    jrnl.DisplayAll();

                    break;
                case 3:
                    // Load the journal file
                    jrnl.LoadFromFile();

                    break;
                case 4:
                    // Save the journal to a file
                    jrnl.SaveToFile();

                    break;
                case 5:
                    // Exit the program
                    // check if unsaved entries exist
                    if (!(jrnl._jrnl.Count == 0))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\tYou have unsaved journal entries. Save them before exiting (y or n)? ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string userResp = Console.ReadLine();
                        if ((userResp == "y") || (userResp == "Y"))
                        {
                            jrnl.SaveJrnlFile();
                            Console.WriteLine("\n\tThank you and Goodbye!\n");
                            System.Environment.Exit(0);
                        }
                    }
                    Console.WriteLine("\n\tThank you and Goodbye!\n");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n\tInvalid Option ... Please try again.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
    static int Choices()
    {
        string choices = @"
        Journal App Menu Options
        
        1. Write
        2. Display
        3. Load
        4. Save
        5. Quit
        
        Please enter your choice: ";
        Console.Write(choices);
        string userInput = Console.ReadLine();
        int action = 0;

        // Test the input options for validity
        try
        {
            action = int.Parse(userInput);
        }
        catch (FormatException)
        {
            action = 0;
        }
        catch (Exception exception)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\t\tUnexpected error:  {exception.Message}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        return action;
    }

}
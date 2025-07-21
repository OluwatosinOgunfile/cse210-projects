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
                    Entry entry = jrnl.AddEntry();

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
                    if (!(jrnl._entries.Count == 0))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\tYou have unsaved journal entries. Save them before exiting (y or n)? ");
                        Console.ForegroundColor = ConsoleColor.White;
                        string userResp = Console.ReadLine();
                        if ((userResp == "y") || (userResp == "Y"))
                        {
                            jrnl.SaveToFile();
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

// Stretch Requirements
// 1. Display message when there is no journal entry to display.
// 2. The journal entries list is emptied when entries are saved.
// 3. When quitting, check and warn if the journal entries list is not empty. (i.e. unsaved entries)
// 4. Display message when there is no entry to save (journal entry list is empty)
// 5. Display message when the file to save to does not exist.
// 6. When a filename is entered to save to, check if it exists first. If it exists, add the entries
//    to the file. If the file does not exist, ask if to create it and add the entries.
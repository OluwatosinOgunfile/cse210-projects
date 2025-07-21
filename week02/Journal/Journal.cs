public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    private string _userFileName;

    static string GetTimeStamp()
    {
        DateTime now = DateTime.Now;
        string currDateTime = now.ToShortDateString();
        return currDateTime;
    }
    public Journal()
    {
        if (_entries.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\n\tNo journal entries to display.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine("\n\t===   Your Journal Entries   ===");
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
            Console.WriteLine("\n\t===      End of Entries      ===");
        }

    }

    private static PromptGenerator jp = new PromptGenerator();
    public void AddEntry()
    {
        string dateInfo = GetTimeStamp();

        string prompt = jp.GetRandomPrompt();

        Entry entry = new Entry();

        Console.Write($"\n\t{prompt}\n");
        Console.Write("\t>>> ");
        string userEntry = Console.ReadLine();

        entry._date = dateInfo;
        entry._promptText = prompt;
        entry._entryText = userEntry;

    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\n\tNo journal entries to display.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.WriteLine("\n\t===   Your Journal Entries   ===");
            foreach (Entry jrnlEntry in _entries)
            {
                jrnlEntry.Display();
            }
            Console.WriteLine("\n\t===      End of Entries      ===");
        }

    }

    public void SaveToFile()
    {
        if (_entries.Count == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\n\tNo journal entries to save.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.Write("\n\tEnter filename to save to: ");
            string userInput = Console.ReadLine();
            _userFileName = userInput + ".txt";

            if (File.Exists(_userFileName))
            {
                // Append journal entries
                using (StreamWriter outputFile = new StreamWriter(_userFileName, append: true))
                {
                    foreach (Entry entry in _entries)
                    {
                        outputFile.WriteLine($"{entry._date}; {entry._promptText}; {entry._entryText}");
                    }
                }
                Console.Write($"\tJournal entries have been successfully added to the {_userFileName}.\n");
                // reset journal file
                _entries.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\t{_userFileName} does not exist. Create the file and save the entries (y or n)? ");
                Console.ForegroundColor = ConsoleColor.White;
                string userResp = Console.ReadLine();

                if ((userResp == "y") || (userResp == "Y"))
                {
                    using (StreamWriter outputFile = new StreamWriter(_userFileName))
                    {
                        foreach (Entry entry in _entries)
                        {
                            outputFile.WriteLine($"{entry._date}; {entry._promptText}; {entry._entryText}");
                        }
                    }

                    Console.Write($"\n\tCreated {_userFileName} successfully.\n");
                    Console.Write("\tJournal entries recorded.\n");
                    // reset journal file
                    _entries.Clear();
                }
            }
        }

    }

    public void LoadFromFile()
    {
        Console.Write("\n\tEnter the filename to load: ");
        string userInput = Console.ReadLine();
        _userFileName = userInput + ".txt";
        if (File.Exists(_userFileName))
        {
            if (_userFileName.Length > 0)
            {
                List<string> readText = File.ReadAllLines(_userFileName).Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();
                foreach (string line in readText)
                {
                    string[] entries = line.Split("; ");
                    Entry entry = new Entry();

                    entry._date = entries[0];
                    entry._promptText = entries[1];
                    entry._entryText = entries[2];
                    _entries.Add(entry);
                }
                Console.Write($"\tJournal entries from {_userFileName} have been successfully loaded.\n");
                // empty loaded file
                string sourceFile = "blank.txt";
                File.Copy(sourceFile, _userFileName, true);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\n\t{_userFileName} is empty. Please try again.\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\n\t{_userFileName} does not exist. Please try again.\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
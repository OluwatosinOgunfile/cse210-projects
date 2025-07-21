public class Entry
{
    public string _date;

    public string _promptText;

    public string _entryText;
    public Entry()
    {

    }
    public void Display()
    {
        Console.WriteLine($"\n\tDate: {_date}");
        Console.WriteLine($"\tPrompt: {_promptText}");
        Console.WriteLine($"\tEntry: {_entryText}");
    }
}
using System;

public class Scripture
{
    // Variables
    public List<Scripture> _scripture = new List<Scripture>();

    // file containing the scripture references
    private string _fileName = "DataText.txt";
    private string _key;
    private string _text;
    public int _index;
    public string _scriptureText;


    // Methods
    public void LoadScriptures()
    {
        List<string> readText = File.ReadAllLines(_fileName).Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();

        foreach (string line in readText)
        {
            string[] entries = line.Split("'");

            Scripture entry = new Scripture();

            entry._key = entries[0];
            entry._text = entries[5];

            _scripture.Add(entry);
        }
    }

    public string RandomScripture()
    {
        _index = GetRandomIndex();
        return _scriptureText = _scripture[_index]._text;
    }
    public int GetRandomIndex()
    {
        var random = new Random();
        _index = random.Next(_scripture.Count);
        return _index;
    }
}
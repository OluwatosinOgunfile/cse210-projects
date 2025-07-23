using System;
using System.ComponentModel;

public class Reference
{
    // Variables
    public List<Reference> _reference = new List<Reference>();
    private string _fileName = "DataText.txt";
    private string _key;
    private string _book;
    private int _chapter;
    private int _verseStart;
    private int _verseEnd;

    public void LoadReference()
    {
        // read in all the scripture references from the static file 'DataText.txt' stored in _fileName
        List<string> readText = File.ReadAllLines(_fileName).Where(arg => !string.IsNullOrWhiteSpace(arg)).ToList();

        // read each scripture into the reference variable
        foreach (string line in readText)
        {
            // split each line into key[0], book[1], chapter[2], verseStart[3], verseEnd[4] using the 
            // delimiter ';' and store in the variable 'entries'
            string[] entries = line.Split("'");

            Reference entry = new Reference();

            entry._key = entries[0];
            entry._book = entries[1];
            entry._chapter = int.Parse(entries[2]);
            entry._verseStart = int.Parse(entries[3]);
            entry._verseEnd = int.Parse(entries[4]);

            // add the read and splitted entry
            _reference.Add(entry);
        }
    }

    public string GetReference(Scripture scripture)
    {
        var index = scripture._index;

        var refi = _reference[index];
        string ref1;
        if (refi._verseEnd.Equals(0))
        {
            return ref1 = ($"\n{refi._book} {refi._chapter}:{refi._verseStart}");

        }
        else
        {
            return ref1 = $"\n{refi._book} {refi._chapter}:{refi._verseStart}-{refi._verseEnd}";
        }
    }

}

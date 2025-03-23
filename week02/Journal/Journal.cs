using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        Console.WriteLine("\nYour Journal Entries:");
        for (int i = 0; i < _entries.Count; i++)
        {
            Console.WriteLine($"[{i}]");
            _entries[i].Display();
            Console.WriteLine("------------------------");
        }
    }

    public void Save(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry._date);
                    writer.WriteLine(entry._promptText);
                    writer.WriteLine(entry._entryText);
                }
            }
            Console.WriteLine($"Journal saved to {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving file: " + ex.Message);
        }
    }

    public void Load(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            _entries.Clear();
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    Entry entry = new Entry
                    {
                        _date = reader.ReadLine(),
                        _promptText = reader.ReadLine(),
                        _entryText = reader.ReadLine()
                    };
                    _entries.Add(entry);
                }
            }
            Console.WriteLine($"Journal loaded from {filename}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading file: " + ex.Message);
        }
    }

 
    public void ViewEntriesByDate()
    {
        Console.Write("\nEnter the date (dd/MM/yyyy) to search for: ");
        string searchDate = Console.ReadLine();

        Console.WriteLine($"\nSearching for entries on {searchDate}...\n");

        bool found = false;
        foreach (Entry entry in _entries)
        {
            if (entry._date == searchDate)
            {
                entry.Display();
                Console.WriteLine("------------------------");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No entries found for this date.");
        }
    }


    public void SearchEntriesByKeyword()
    {
        Console.Write("\nEnter a keyword to search for: ");
        string keyword = Console.ReadLine().ToLower();

        Console.WriteLine($"\nSearching for entries containing \"{keyword}\"...\n");

        bool found = false;
        foreach (Entry entry in _entries)
        {
            if (entry._promptText.ToLower().Contains(keyword) || entry._entryText.ToLower().Contains(keyword))
            {
                entry.Display();
                Console.WriteLine("------------------------");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No entries found containing that keyword.");
        }
    }

      public void EditEntry()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries available to edit.");
            return;
        }
        DisplayAll();
        Console.Write("Enter the index of the entry you want to edit: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < _entries.Count)
        {
            Console.WriteLine("Editing the following entry:");
            _entries[index].Display();
            Console.Write("Enter the new entry text: ");
            string newText = Console.ReadLine();
            _entries[index]._entryText = newText;
        
            _entries[index]._date = DateTime.Now.ToString("dd/MM/yyyy");
            Console.WriteLine("Entry updated.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }

  
    public void DeleteEntry()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries available to delete.");
            return;
        }
        DisplayAll();
        Console.Write("Enter the index of the entry you want to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index >= 0 && index < _entries.Count)
        {
            _entries.RemoveAt(index);
            Console.WriteLine("Entry deleted.");
        }
        else
        {
            Console.WriteLine("Invalid index.");
        }
    }
}

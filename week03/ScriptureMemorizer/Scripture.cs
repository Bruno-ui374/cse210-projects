using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    // Use a static Random instance to avoid reinitializing on every call.
    private static Random _rand = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        // Split the scripture text by space and create a Word object for each word.
        _words = text.Split(' ')
                     .Select(word => new Word(word))
                     .ToList();
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference.ToString());
        Console.WriteLine();
        Console.WriteLine(GetRenderedText());
    }

    public void HideRandomWords(int count = 3)
    {
        // Get a list of words that are not yet hidden.
        var visibleWords = _words.Where(w => !w.IsHidden).ToList();

        // Hide up to 'count' random words.
        for (int i = 0; i < count && visibleWords.Count > 0; i++)
        {
            int index = _rand.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden()
    {
        return _words.All(w => w.IsHidden);
    }

    private string GetRenderedText()
    {
        return string.Join(" ", _words.Select(w => w.GetDisplayText()));
    }
}

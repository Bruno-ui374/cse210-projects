using System;
using System.Linq;

public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    public Reference(string book, int chapter, int verse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = verse;
        EndVerse = null;
    }

    
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    
    public static Reference Parse(string referenceText)
    {
        int colonIndex = referenceText.IndexOf(':');
        if (colonIndex < 0)
            throw new FormatException("Reference must contain a colon (:) separating chapter and verse.");

      
        string bookAndChapter = referenceText.Substring(0, colonIndex).Trim();
        
        string versePart = referenceText.Substring(colonIndex + 1).Trim();

        
        var tokens = bookAndChapter.Split(' ');
        if (tokens.Length < 2)
            throw new FormatException("Reference must include a book and a chapter.");

        int chapter = int.Parse(tokens[tokens.Length - 1]);
        string book = string.Join(" ", tokens.Take(tokens.Length - 1));

        if (versePart.Contains("-"))
        {
            var verseTokens = versePart.Split('-');
            int startVerse = int.Parse(verseTokens[0]);
            int endVerse = int.Parse(verseTokens[1]);
            return new Reference(book, chapter, startVerse, endVerse);
        }
        else
        {
            int verse = int.Parse(versePart);
            return new Reference(book, chapter, verse);
        }
    }

    public override string ToString()
    {
        return EndVerse.HasValue 
            ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}" 
            : $"{Book} {Chapter}:{StartVerse}";
    }
}

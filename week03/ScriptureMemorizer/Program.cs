using System;
using System.Collections.Generic;

namespace ScriptureMemorization
{
    class Program
    {
        static void Main(string[] args)
        {
            ScriptureLibrary library = new ScriptureLibrary();
            while (true)
            {
                Scripture scripture = library.GetRandomScripture();
                scripture.DisplayFullScripture();
                Console.WriteLine("\nPress Enter to hide the next word or type 'quit' to finish.");
                while (!scripture.AllWordsHidden())
                {
                    string input = Console.ReadLine();
                    if (input.ToLower() == "quit")
                        return;
                    scripture.HideRandomWord();
                    scripture.DisplayScripture();
                    if (!scripture.AllWordsHidden())
                        Console.WriteLine("Press Enter to hide the next word or type 'quit' to finish.");
                    else
                        Console.WriteLine("All words hidden.");
                }
                Console.WriteLine("Do you want to memorize another scripture? Press '2' to continue, or just press Enter to finish.");
                string answer = Console.ReadLine();
                if (answer != "2")
                    break;
            }
        }
    }
}

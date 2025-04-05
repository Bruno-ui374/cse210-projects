using System;
using System.Diagnostics;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
       
        ScriptureLibrary library = new ScriptureLibrary();

        
        while (true)
        {
            List<Scripture> scriptures = library.GetRandomScriptures();

     
            if (scriptures.Count == 0)
            {
                Console.WriteLine("\nYou have completed your scripture memorizing for the day!");
                break;
            }

       
            Scripture scripture = scriptures[new Random().Next(scriptures.Count)];

            if (scripture == null)
            {
                Console.WriteLine("No scriptures available.");
                return;
            }

        
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

           
            scripture.Display();
            Console.WriteLine("\nPress Enter to begin memorizing or type 'quit' to finish.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                stopwatch.Stop();
                Console.WriteLine($"\nTime elapsed: {stopwatch.Elapsed}");
                break;
            }

            
            while (true)
            {
                scripture.HideRandomWords();
                scripture.Display();

                if (scripture.AllWordsHidden())
                {
                    stopwatch.Stop();
                    Console.WriteLine("\nAll words are now hidden.");
                    Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");
                    break;
                }

                Console.WriteLine("\nPress Enter to hide more words or type 'quit' to finish.");
                input = Console.ReadLine().Trim().ToLower();
                if (input == "quit")
                {
                    stopwatch.Stop();
                    Console.WriteLine($"\nTime elapsed: {stopwatch.Elapsed}");
                    return;
                }
            }

         
            library.MarkAsUsed(scripture);

            Console.WriteLine("\nDo you want to memorize another scripture?");
            Console.WriteLine("Press '2' to load another scripture from the list, or just press Enter to finish.");
            input = Console.ReadLine().Trim();
            if (input == "2")
            {
                
                continue;
            }
            else
            {
                
                break;
            }
        }
    }
}

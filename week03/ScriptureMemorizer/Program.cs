using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ScriptureMemorization
{
    class Program
    {
        static void Main(string[] args)
        {
            var scriptureLibrary = new ScriptureLibrary();
            var randomScriptures = scriptureLibrary.GetRandomScriptures();
            var timer = new Stopwatch();

            while (true)
            {
                if (randomScriptures.Count == 0)
                {
                    Console.WriteLine("You have completed your scripture memorizing for the day!");
                    break;
                }

                var scripture = randomScriptures[0];
                randomScriptures.RemoveAt(0);

                scripture.DisplayFullScripture();
                timer.Start();

                Console.WriteLine("\nPress Enter to continue or type 'quit' to finish.");

                while (true)
                {
                    var input = Console.ReadLine();

                    if (input.ToLower() == "quit")
                    {
                        Console.WriteLine("Thank you for memorizing! Exiting...");
                        return;
                    }

                    if (string.IsNullOrEmpty(input))
                    {
                        scripture.HideRandomWords();
                        scripture.DisplayScripture();

                        if (scripture.AllWordsHidden())
                        {
                            timer.Stop();
                            Console.WriteLine($"Time taken: {timer.Elapsed.TotalSeconds} seconds");
                            timer.Reset();

                            Console.WriteLine("Do you want to memorize another scripture? Press '2' to continue, or just press Enter to finish.");
                            var nextAction = Console.ReadLine();

                            if (nextAction == "2")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Thanks for memorizing today! Goodbye.");
                                return;
                            }
                        }
                    }
                }
            }
        }
    }
}

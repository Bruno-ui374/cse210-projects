using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    public class GratitudeActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "List three things you are grateful for today.",
            "Reflect on a person who made your day better.",
            "Think of an opportunity that influenced you positively.",
            "Name an accomplishment that you cherish."
        };

        public GratitudeActivity()
            : base("Gratitude Activity",
                   "This activity encourages you to focus on positivity by reflecting on what you are grateful for. " +
                   "It is a moment to appreciate the good in your life.")
        {
        }

      
        private string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }

        public override void Run()
        {
            DisplayStartingMessage();

            Console.WriteLine();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine();
            string prompt = GetRandomPrompt();
            Console.WriteLine($"---{prompt}---");
            Console.WriteLine();
            Console.WriteLine("Take a moment to reflect...");
            ShowCountDown(5);

            Console.WriteLine();
            List<string> gratitudeEntries = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    break;
                gratitudeEntries.Add(input);
            }

            Console.WriteLine();
            Console.WriteLine($"You entered {gratitudeEntries.Count} gratitude thought(s).");

            DisplayEndingMessage();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };

        public ListingActivity()
            : base("Listing Activity",
                   "This activity will help you reflect on the good things in your life by having you list as many items as possible in a given category.")
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
            Console.WriteLine("You have a few seconds to think about it...");
            ShowCountDown(5);

            Console.WriteLine();

            List<string> userItems = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                userItems.Add(input);
            }

            Console.WriteLine();
            Console.WriteLine($"You listed {userItems.Count} item(s).");

            DisplayEndingMessage();
        }
    }
}

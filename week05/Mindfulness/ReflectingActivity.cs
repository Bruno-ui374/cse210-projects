using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    public class ReflectingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        public ReflectingActivity()
            : base("Reflecting Activity",
                   "This activity will help you reflect on times in your life when you have shown strength and resilience. " +
                   "Reflect on a moment when you overcame a challenge or made a significant impact.")
        {
        }

        private string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }

       
        private string GetRandomQuestion()
        {
            Random random = new Random();
            int index = random.Next(_questions.Count);
            return _questions[index];
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
            Console.Write("Now ponder on each of the following questions as they are related to this experience: You may begin in ");
            ShowCountDown(3);

            DateTime endTime = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < endTime)
            {
                string question = GetRandomQuestion();
                Console.WriteLine();
                Console.WriteLine($"> {question}");
                ShowSpinner(5);
            }

            DisplayEndingMessage();
        }
    }
}

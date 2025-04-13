using System;
using System.Threading;

namespace MindfulnessApp
{
   
    public abstract class Activity
    {
      
        protected string _activityName;
        protected string _description;
        protected int _duration; 

        public Activity(string activityName, string description)
        {
            _activityName = activityName;
            _description = description;
        }

       
        public virtual void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine($"Welcome to the {_activityName}.");
            Console.WriteLine();
            Console.WriteLine($"{_description}");
            Console.WriteLine();
            Console.Write("Enter the duration (in seconds) for this activity: ");
            int.TryParse(Console.ReadLine(), out _duration);
            Console.WriteLine();
            Console.WriteLine("Get ready...");
            ShowSpinner(3);
        }

        
        public virtual void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Well done!");
            ShowSpinner(5);
            Console.WriteLine($"You have completed the {_activityName} for {_duration} seconds.");
            ShowSpinner(3);
        }

        
        protected void ShowSpinner(int durationInSeconds)
        {
            int endTime = Environment.TickCount + durationInSeconds * 1000;
            while (Environment.TickCount < endTime)
            {
                Console.Write("|");
                Thread.Sleep(250);
                Console.Write("\b \b");
                Console.Write("/");
                Thread.Sleep(250);
                Console.Write("\b \b");
                Console.Write("-");
                Thread.Sleep(250);
                Console.Write("\b \b");
                Console.Write("\\");
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }

        protected void ShowCountDown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }

       
        public abstract void Run();
    }
}

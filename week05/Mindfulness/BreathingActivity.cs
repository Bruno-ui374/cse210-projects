using System;
using System.Threading;

namespace MindfulnessApp
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity()
            : base("Breathing Activity",
                   "This activity will help you relax by guiding your breathing. Clear your mind, focus on your breath, and allow your body to unwind.")
        {
        }

        public override void Run()
        {
            DisplayStartingMessage();

            int elapsedTime = 0;
            while (elapsedTime < _duration)
            {
                Console.WriteLine();
                Console.Write("Breathe in...");
                ShowCountDown(4);
                elapsedTime += 4;
                if (elapsedTime >= _duration)
                    break;

                Console.WriteLine();
                Console.Write("Breathe out...");
                
                ShowCountDown(6);
                elapsedTime += 6;
            }

            DisplayEndingMessage();
        }
    }
}

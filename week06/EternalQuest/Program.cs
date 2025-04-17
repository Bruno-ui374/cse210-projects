// Program.cs
using System;
using System.Threading;

public class Program
{
    public static void Main()
    {
        GoalManager goalManager = new GoalManager();
        bool quit = false;

        while (!quit)
        {
            Console.Clear();
            goalManager.DisplayScore();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");

            Console.Write("\nSelect a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    goalManager.CreateGoal();
                    break;

                case "2":
                    goalManager.ListGoals();
                    break;

                case "3":
                    goalManager.SaveGoals();
                    break;

                case "4":
                    goalManager.LoadGoals();
                    break;

                case "5":
                    goalManager.RecordEvent();
                    break;

                case "6":
                    quit = true;
                    break;

                default:
                    Console.WriteLine("\nInvalid choice.");
                    break;
            }
            // Adjust delay based on choice to allow more time to view listings.
            int delay = (choice == "2") ? 3000 : 1500;
            Thread.Sleep(delay);
        }

        // On quitting, display the summary and exit immediately.
        Console.Clear();
        Console.WriteLine("Exiting Program...");
        goalManager.PrintSummary();
    }
}
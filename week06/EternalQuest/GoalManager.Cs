// GoalManager.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    // Displays the current user score.
    public void DisplayScore()
    {
        Console.WriteLine($"You have {_score} points.\n");
    }

    // Creates a new goal based on user inputs.
    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("\nWhich type of goal do you want to create? ");
        string typeInput = Console.ReadLine();

        Console.Write("\nWhat is the name of your goal? ");
        string name = Console.ReadLine();

        Console.Write("\nWhat is the short description of it? ");
        string description = Console.ReadLine();

        Console.Write("\nHow many points do you want associated with this goal? ");
        int points;
        while (!int.TryParse(Console.ReadLine(), out points))
        {
            Console.Write("\nPlease enter a valid number for points: ");
        }

        switch (typeInput)
        {
            case "1":
                _goals.Add(new SimpleGoal(name, description, points));
                break;

            case "2":
                _goals.Add(new EternalGoal(name, description, points));
                break;

            case "3":
                Console.Write("\nHow many times does this goal need to be accomplished to get a bonus? ");
                int target;
                while (!int.TryParse(Console.ReadLine(), out target))
                {
                    Console.Write("\nPlease enter a valid number for target: ");
                }

                Console.Write("\nWhat is the bonus for accomplishing it that many times? ");
                int bonus;
                while (!int.TryParse(Console.ReadLine(), out bonus))
                {
                    Console.Write("\nPlease enter a valid number for bonus: ");
                }

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
                break;

            default:
                Console.WriteLine("\nInvalid choice. Goal not created.");
                break;
        }
    }

    // Lists all goals with their current completion details.
    public void ListGoals()
    {
        Console.WriteLine("\nThe goals are:\n");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.\n");
            return;
        }

        int i = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            i++;
        }
        Console.WriteLine();
    }

    // Displays a simple loading animation.
    private void ShowLoadingAnimation(string message)
    {
        Console.Write(message);
        for (int i = 0; i < 3; i++)
        {
            Console.Write(".");
            Thread.Sleep(400);
        }
        Console.WriteLine();
    }

    // Saves the score and each goal’s state to a file.
    public void SaveGoals()
    {
        Console.Write("\nEnter the file name to save to: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter sw = new StreamWriter(filename))
            {
                // Save the current score on the first line.
                sw.WriteLine(_score);
                // Save each goal in CSV format.
                foreach (Goal goal in _goals)
                {
                    sw.WriteLine(goal.GetStringRepresentation());
                }
            }
            ShowLoadingAnimation("Saving");
            Console.WriteLine("\nGoals saved successfully.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while saving: {ex.Message}\n");
        }
    }

    // Loads the score and goals from a file.
    public void LoadGoals()
    {
        Console.Write("\nEnter the file name to load from: ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                _goals.Clear();
                string scoreLine = sr.ReadLine();
                int.TryParse(scoreLine, out _score);

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 4)
                    {
                        string goalType = parts[0];
                        string name = parts[1];
                        string description = parts[2];
                        int points = int.Parse(parts[3]);

                        switch (goalType)
                        {
                            case "SimpleGoal":
                                bool isComplete = parts.Length > 4 && parts[4].Trim().ToLower() == "true";
                                var simpleGoal = new SimpleGoal(name, description, points);
                                if (isComplete)
                                {
                                    // Mark the goal as completed.
                                    simpleGoal.RecordEvent();
                                }
                                _goals.Add(simpleGoal);
                                break;

                            case "EternalGoal":
                                _goals.Add(new EternalGoal(name, description, points));
                                break;

                            case "ChecklistGoal":
                                if (parts.Length >= 7)
                                {
                                    int target = int.Parse(parts[4]);
                                    int bonus = int.Parse(parts[5]);
                                    int amountCompleted = int.Parse(parts[6]);
                                    ChecklistGoal checklistGoal = new ChecklistGoal(name, description, points, target, bonus);
                                    // Simulate previously recorded progress.
                                    for (int i = 0; i < amountCompleted; i++)
                                    {
                                        checklistGoal.RecordEvent();
                                    }
                                    _goals.Add(checklistGoal);
                                }
                                break;

                            default:
                                Console.WriteLine($"\nUnknown goal type: {goalType}");
                                break;
                        }
                    }
                }
            }
            ShowLoadingAnimation("Loading");
            Console.WriteLine("\nGoals loaded successfully.\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nAn error occurred while loading: {ex.Message}\n");
        }
    }

    // Records an event by letting the user choose the type of goal they accomplished.
    public void RecordEvent()
    {
        Console.WriteLine("\nWhat kind of goal did you accomplish today?");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("\nSelect the goal type: ");
        string typeChoice = Console.ReadLine();

        IEnumerable<Goal> filteredGoals = null;
        switch (typeChoice)
        {
            case "1":
                filteredGoals = _goals.Where(g => g is SimpleGoal);
                break;
            case "2":
                filteredGoals = _goals.Where(g => g is EternalGoal);
                break;
            case "3":
                filteredGoals = _goals.Where(g => g is ChecklistGoal);
                break;
            default:
                Console.WriteLine("\nInvalid goal type choice.");
                return;
        }

        var availableGoals = filteredGoals.ToList();
        if (availableGoals.Count == 0)
        {
            Console.WriteLine("\nThere are no goals of that type currently available.\n");
            return;
        }

        Console.WriteLine("\nThe available goals of this type are:\n");
        for (int i = 0; i < availableGoals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableGoals[i].GetDetailsString()}");
        }

        Console.Write("\nEnter the number of the goal you accomplished: ");
        int selection;
        while (!int.TryParse(Console.ReadLine(), out selection) || selection < 1 || selection > availableGoals.Count)
        {
            Console.Write("\nPlease enter a valid goal number: ");
        }

        Goal selectedGoal = availableGoals[selection - 1];
        int earnedPoints = selectedGoal.RecordEvent();

        if (earnedPoints > 0)
        {
            _score += earnedPoints;
            Console.WriteLine($"\nCongratulations! You have earned {earnedPoints} points.");
            Console.WriteLine($"You now have {_score} points.\n");
        }
        else
        {
            // For checklist goals, show appropriate message when progress is updated.
            if (selectedGoal is ChecklistGoal)
            {
                if (!selectedGoal.IsComplete())
                {
                    Console.WriteLine("\nProgress recorded for checklist goal (no points until complete).\n");
                }
                else
                {
                    Console.WriteLine("\nThis checklist goal is already complete.\n");
                }
            }
            else
            {
                Console.WriteLine("\nThis goal cannot be recorded further or is already complete.\n");
            }
        }
    }

    // When quitting, print a summary of each completed goal.
    public void PrintSummary()
    {
        Console.WriteLine("\n--- Goal Completion Summary ---\n");
        int completedCount = 0;
        foreach (var goal in _goals)
        {
            if (goal.IsComplete())
            {
                Console.WriteLine(goal.GetCompletionSummary());
                completedCount++;
            }
        }
        if (completedCount == 0)
        {
            Console.WriteLine("No goals were completed.");
        }
    }
}
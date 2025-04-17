// ChecklistGoal.cs
using System;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _amountCompleted;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    // Each record increases the count but awards points only when the checklist is fully complete.
    public override int RecordEvent()
    {
        if (!IsComplete())
        {
            _amountCompleted++;
            _recordTimestamps.Add(DateTime.Now);
            if (IsComplete())
                return _points + _bonus;
            return 0; // No points until the checklist is complete.
        }
        return 0;
    }

    // The checklist goal is complete when the required number of completions is reached.
    public override bool IsComplete() => _amountCompleted >= _target;

    // Displays the goal status with the current progress.
    public override string GetDetailsString()
        => $"[ {(IsComplete() ? "X" : " ")} ] {_name} ({_description}) --- Completed: {_amountCompleted}/{_target}";

    // When saving, include the current progress count.
    public override string GetStringRepresentation()
        => $"ChecklistGoal,{_name},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
}
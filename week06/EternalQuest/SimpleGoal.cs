// SimpleGoal.cs
using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    // Record the event only if it hasn’t been marked complete; if successful, record the time and return the point value.
    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            _recordTimestamps.Add(DateTime.Now);
            return _points;
        }
        return 0;
    }

    public override bool IsComplete() => _isComplete;

    // Displays the goal with a checkbox.
    public override string GetDetailsString()
        => $"[ {(_isComplete ? "X" : " ")} ] {_name} ({_description})";

    // File representation format: type, name, description, points, and a completion flag.
    public override string GetStringRepresentation()
        => $"SimpleGoal,{_name},{_description},{_points},{(_isComplete ? "true" : "")}";
}
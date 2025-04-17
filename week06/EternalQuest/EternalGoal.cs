// EternalGoal.cs
using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    { }

    // Every time it's recorded, record the time and award the set points.
    public override int RecordEvent()
    {
        _recordTimestamps.Add(DateTime.Now);
        return _points;
    }

    // Eternal goals are never considered complete.
    public override bool IsComplete() => false;

    // Always displayed unchecked.
    public override string GetDetailsString()
        => $"[ ] {_name} ({_description})";

    // File format without a completion flag.
    public override string GetStringRepresentation()
        => $"EternalGoal,{_name},{_description},{_points}";
}
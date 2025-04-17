// Goal.cs
using System;
using System.Collections.Generic;

public abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected DateTime _creationTime;
    protected List<DateTime> _recordTimestamps;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _creationTime = DateTime.Now;
        _recordTimestamps = new List<DateTime>();
    }

    // Called when the goal is recorded (i.e. accomplished)
    public abstract int RecordEvent();

    // Returns true if the goal is complete (for Simple and Checklist types)
    public abstract bool IsComplete();

    // Returns a string to display the goal's details on the list view
    public abstract string GetDetailsString();

    // Returns a CSV-friendly string for saving goals to a file
    public abstract string GetStringRepresentation();

    // Returns a summary string showing number of completions and elapsed time (if complete)
    public virtual string GetCompletionSummary()
    {
        if (!IsComplete() || _recordTimestamps.Count == 0)
        {
            return $"{_name}: Not completed.";
        }

        // For completed goals, use the timestamp of the final record.
        DateTime finishTime = _recordTimestamps[_recordTimestamps.Count - 1];
        TimeSpan elapsed = finishTime - _creationTime;
        return $"{_name}: Completed {_recordTimestamps.Count} time(s) in {elapsed}.";
    }
}
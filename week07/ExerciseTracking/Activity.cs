using System;

namespace ExerciseTracker
{
    public abstract class Activity
    {
        private readonly DateTime _date;
        private readonly double _duration; // in minutes

        protected Activity(DateTime date, double duration)
        {
            _date = date;
            _duration = duration;
        }

        public DateTime Date => _date;
        public double Duration => _duration;

        public abstract double GetDistance(); // miles
        public abstract double GetSpeed();    // mph
        public abstract double GetPace();     // mins per mile
        public abstract string GetActivityType();

        public virtual string GetSummary()
        {
            var dateStr = Date.ToString("dd MMM yyyy");
            return $"{dateStr} {GetActivityType()} ({Duration} min) – " +
                   $"Distance {GetDistance():F1} mi, Speed {GetSpeed():F1} mph, Pace {GetPace():F1} min/mi";
        }
    }
}

using System;
using System.Collections.Generic;

namespace ExerciseTracker
{
    class Program
    {
        static void Main()
        {
            var activities = new List<Activity>
            {
                new RunningActivity(new DateTime(2022, 11, 3), 30, 3.0), //date, duration, distance
                new Cycling(       new DateTime(2022, 11, 4), 30, 10.0),
                new Swimming(      new DateTime(2022, 11, 5), 30, 20)
            };

            foreach (var act in activities)
                Console.WriteLine(act.GetSummary());
        }
    }
}

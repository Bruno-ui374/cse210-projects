using System;

namespace ExerciseTracker
{
    public class RunningActivity : Activity
    {
        private readonly double _distance;

        public RunningActivity(DateTime date, double duration, double distance)
            : base(date, duration)
        {
            _distance = distance;
        }

        public override double GetDistance() => _distance;
        public override double GetSpeed() => (_distance / Duration) * 60;
        public override double GetPace() => Duration / _distance;
        public override string GetActivityType() => "Running";
    }
}

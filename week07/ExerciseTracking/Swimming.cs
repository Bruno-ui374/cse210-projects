using System;

namespace ExerciseTracker
{
    public class Swimming : Activity
    {
        private readonly int _laps;

        public Swimming(DateTime date, double duration, int laps)
            : base(date, duration)
        {
            _laps = laps;
        }

        // 1 lap = 50 m; 1 mile ≈ 1000 m * 0.62
        public override double GetDistance() => _laps * 50.0 / 1000.0 * 0.62;
        public override double GetSpeed() => (GetDistance() / Duration) * 60;
        public override double GetPace() => Duration / GetDistance();
        public override string GetActivityType() => "Swimming";
    }
}

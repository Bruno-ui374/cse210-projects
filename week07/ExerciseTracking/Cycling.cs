using System;

namespace ExerciseTracker
{
    public class Cycling : Activity
    {
        private readonly double _speed; //  mph

        public Cycling(DateTime date, double duration, double speed)
            : base(date, duration)
        {
            _speed = speed;
        }

        public override double GetSpeed() => _speed;
        public override double GetDistance() => _speed * (Duration / 60.0);
        public override double GetPace() => Duration / GetDistance();
        public override string GetActivityType() => "Cycling";
    }
}

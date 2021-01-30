namespace _40Stats.Core.Rolls
{
    internal record HitRoll : Roll
    {

        internal HitRoll(int expectedValue, int rollResult) : base(expectedValue, rollResult)
        {
            Hit = !Missed;
        }

        public bool Hit { get; init; }
    }
}
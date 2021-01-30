namespace _40Stats.Core.Rolls
{
    public record HitRoll : Roll
    {

        public HitRoll(int expectedValue, int rollResult) : base(expectedValue, rollResult)
        {
            Hit = !Missed;
        }

        public bool Hit { get; init; }
    }
}
namespace _40Stats.Core.Rolls
{
    public record WoundRoll : Roll
    {

        public WoundRoll(int expected, int roll) : base(expected, roll)
        {
            Wounded = !Missed;
        }

        public bool Wounded { get; init; }
    }
}
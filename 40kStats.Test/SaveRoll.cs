namespace _40Stats.Core.Rolls
{
    internal record SaveRoll : Roll
    {
        public SaveRoll(int Expected, int RollResult) : base(Expected, RollResult)
        {
            Saved = !Missed;
        }

        public bool Saved { get; init; }
    }
}
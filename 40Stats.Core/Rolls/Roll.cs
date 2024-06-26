﻿namespace _40Stats.Core.Rolls
{
    public record Roll
    {
        public Roll(int expectedValue, int rollResult)
        {
            Expected = expectedValue;
            RollResult = rollResult;
            Missed = RollResult == 1 || RollResult < Expected;
        }

        public int Expected { get; init; }
        public int RollResult { get; init; }
        public bool Missed { get; init; }
    }
}

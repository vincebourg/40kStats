using System;

namespace _40Stats.Core.Dices
{
    public class Dice : IRoll
    {
        public int Roll() => new Random().Next(1, 6);
    }
}
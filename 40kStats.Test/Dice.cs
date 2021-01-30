using System;

namespace _40kStats.Test
{
    internal class Dice
    {
        internal int Roll() => new Random().Next(1, 6);
    }
}
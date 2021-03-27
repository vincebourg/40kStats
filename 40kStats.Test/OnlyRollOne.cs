using _40Stats.Core.Dices;
using System;

namespace _40kStats.Test
{
    public partial class RangedAttacksTests
    {
        internal class OnlyRollOne : IRoll
        {
            public int Roll()
            {
                return 1;
            }
        }
    }
}

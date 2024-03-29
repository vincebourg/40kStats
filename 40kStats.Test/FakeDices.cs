using _40Stats.Core.Dices;

namespace _40kStats.Test
{

    internal class OnlyRollOne : IRoll
    {
        public int Roll()
        {
            return 1;
        }
    }

    internal class OnlyRollTwo : IRoll
    {
        public int Roll()
        {
            return 2;
        }
    }

    internal class OnlyRollThree : IRoll
    {
        public int Roll()
        {
            return 3;
        }
    }
    internal class OnlyRollFour : IRoll
    {
        public int Roll()
        {
            return 4;
        }
    }

    internal class OnlyRollFive : IRoll
    {
        public int Roll()
        {
            return 5;
        }
    }

    internal class OnlyRollSix : IRoll
    {
        public int Roll()
        {
            return 6;
        }
    }
}

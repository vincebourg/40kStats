using System;

namespace _40kStats.Test
{
    internal class WoundThresholdCalculator
    {
        public WoundThresholdCalculator()
        {
        }

        internal int GetThreshold(int strenght, int endurance)
        {
            switch ((float)strenght / (float)endurance)
            {
                case float i when i >= 2:
                    return 2;
                case float i when i > 1:
                    return 3;
                case float i when i == 1:
                    return 4;
                case float i when i > 0.5:
                    return 5;
                default: 
                    return 6;
            }
        }
    }
}
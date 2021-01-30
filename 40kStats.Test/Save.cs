using _40Stats.Core.Rolls;
using System;

namespace _40kStats.Test
{
    internal record Save(int Expected) 
    {
        internal SaveRoll Roll() {
            return new(Expected, new Dice().Roll());
        }
    };

}
using _40Stats.Core.Dices;
using _40Stats.Core.Rolls;

namespace _40Stats.Core.Targets
{
    public record Save(int Expected)
    {
        public SaveRoll Roll(IRoll dice, int ArmorPenetration = 0)
        {
            return new(Expected + ArmorPenetration, dice.Roll());
        }
    };

}
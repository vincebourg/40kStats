using _40Stats.Core.Dices;
using _40Stats.Core.Rolls;

namespace _40Stats.Core.Targets
{
    public record Save(int Expected, bool IsInvulnerable = false)
    {
        public SaveRoll Roll(IRoll dice, int ArmorPenetration = 0)
        {
            return new(Expected + (IsInvulnerable ? 0 : ArmorPenetration), dice.Roll());
        }
    };

}
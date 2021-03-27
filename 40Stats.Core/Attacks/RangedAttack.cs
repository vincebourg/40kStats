using _40Stats.Core.Dices;
using _40Stats.Core.Rolls;
using _40Stats.Core.Targets;
using System;

namespace _40Stats.Core.Attacks
{
    public record RangedAttack(Target Target, Shooter Shooter, int WeaponStrenght)
    {
        public HitRoll RollHit(IRoll roller) => new HitRoll(Shooter.BalisticSkill, roller.Roll());

        public WoundRoll RollWound(IRoll roller) => new WoundRoll(
            new WoundThresholdCalculator().GetThreshold(
                WeaponStrenght,
                Target.Endurance),
            roller.Roll()
        );

        public SaveRoll RollSave(IRoll roller) => new SaveRoll(Target.Save?.Expected ?? int.MaxValue, roller.Roll());
    }
}
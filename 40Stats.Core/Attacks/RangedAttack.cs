using _40Stats.Core.Dices;
using _40Stats.Core.Rolls;
using _40Stats.Core.Targets;
using System;

namespace _40Stats.Core.Attacks
{
    public record RangedAttack(Target Target, Shooter Shooter, int WeaponStrenght)
    {
        public HitRoll RollHit() => new HitRoll(Shooter.BalisticSkill, new Dice().Roll());

        public WoundRoll RollWound() => new WoundRoll(
            new WoundThresholdCalculator().GetThreshold(
                WeaponStrenght,
                Target.Endurance),
            new Dice().Roll()
        );

        public SaveRoll RollSave() => new SaveRoll(Target.Save?.Expected ?? 7, new Dice().Roll());
    }
}
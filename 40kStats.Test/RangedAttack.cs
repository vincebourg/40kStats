using _40Stats.Core.Dices;
using _40Stats.Core.Rolls;
using _40Stats.Core.Targets;
using System;

namespace _40kStats.Test
{
    internal record RangedAttack(Target Target, Shooter Shooter, int WeaponStrenght)
    {
        internal HitRoll RollHit() => new HitRoll(Shooter.BalisticSkill, new Dice().Roll());

        internal WoundRoll RollWound() => new WoundRoll(
            new WoundThresholdCalculator().GetThreshold(
                WeaponStrenght,
                Target.Endurance),
            new Dice().Roll()
        );
        
    }
}
using _40Stats.Core.Dices;
using _40Stats.Core.Targets;
using System;
using System.Linq;

namespace _40Stats.Core.Statistics
{
    public record WoundCalculator(Target Target, Shooter Shooter, Weapon Weapon)
    {
        public WoundCalculatorResult Process(IRoll roller)
        {
            var attacks = Shooter.Shoot(Target, Weapon);
            var hits = attacks.Select(a => (attack: a, hitRoll: a.RollHit(roller))).ToArray();
            var wounds = hits.Where(h => h.hitRoll.Hit).Select(h => h.attack.RollWound(roller)).ToArray();
            return new(
                attacks.Count(),
                wounds.Count(),
                wounds.Count(w => w.Wounded)
            );
        }
    }
}
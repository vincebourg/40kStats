using System;
using System.Linq;

namespace _40kStats.Test
{
    internal record WoundCalculator(Target Target, Shooter Shooter, Weapon Weapon)
    {
        internal WoundCalculatorResult Process()
        {
            var attacks = Shooter.Shoot(Target, Weapon);
            var hits = attacks.Select(a => (attack: a,hitRoll: a.RollHit())).ToArray();
            var wounds = hits.Where( h => h.hitRoll.Hit).Select(h => h.attack.RollWound()).ToArray();
            return new(
                attacks.Count(),
                wounds.Count(),
                wounds.Count(w => w.Wounded)
            );
        }
    }
}
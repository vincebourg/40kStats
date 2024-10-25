using _40Stats.Core.Dices;
using _40Stats.Core.Targets;
using System;
using System.Linq;

namespace _40Stats.Core.Statistics
{
    public record WoundCalculator(Target Target, Weapon Weapon)
    {
        public WoundCalculatorResult Process(IRoll roller)
        {
            var attacks = Weapon.Shoot(Target);
            foreach (var attack in attacks)
            {
                attack.Process(roller);
            }
            var hits = attacks.Where(a => a.HasHit).Count();
            var wounds = attacks.Where(a => a.HasWounded).Count();
            var damages = attacks.Where(a => a.HasDamaged).Count();
            return new(
                attacks.Count(),
                hits,
                wounds,
                damages
            );
        }
    }
}
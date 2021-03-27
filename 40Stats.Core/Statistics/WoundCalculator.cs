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
            var wounds = hits.Where(h => h.hitRoll.Hit).Select(a => (attack: a.attack, woundRoll: a.attack.RollWound(roller))).ToArray();
            var saves = wounds.Where(w => w.woundRoll.Wounded).Select(a => (attack: a.attack,saveRoll: a.attack.RollSave(roller))).ToArray();
            return new(
                attacks.Count(),
                wounds.Count(),
                saves.Count(),
                saves.Count(s => s.saveRoll.Missed)
            );
        }
    }
}
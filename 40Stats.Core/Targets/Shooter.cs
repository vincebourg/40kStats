using _40Stats.Core.Attacks;
using System.Collections.Generic;
using System.Linq;

namespace _40Stats.Core.Targets
{
    public record Shooter(int BalisticSkill)
    {
        public IEnumerable<RangedAttack> Shoot(Target target, Weapon weapon)
            => Enumerable.Range(1, weapon.Attacks)
                         .Select(_ => new RangedAttack(target, this, weapon.Strength, weapon.ArmorPenetration));
    };
}